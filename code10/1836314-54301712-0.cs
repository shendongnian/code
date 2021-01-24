namespace BlazorHelper
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net.Mime;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.StaticFiles;
    using Microsoft.Extensions.FileProviders;
    using Microsoft.Net.Http.Headers;
    /// <summary>
    /// Extension methods for registration related to Blazor.
    /// </summary>
    /// <remarks>
    /// This is almost full rip-off of
    /// https://github.com/aspnet/AspNetCore/blob/master/src/Components/src/Microsoft.AspNetCore.Components.Server/Builder/BlazorApplicationBuilderExtensions.cs
    /// </remarks>
    public static class BlazorExtensions
    {
        /// <summary>
        /// Configures the middleware pipeline to work with Blazor.
        /// </summary>
        /// <typeparam name="TProgram">Any type from the client app project. This is used to identify the client app assembly.</typeparam>
        /// <param name="app">The <see cref="IApplicationBuilder"/>.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> with configured Blazor.</returns>
        public static IApplicationBuilder UseLocalBlazor<TProgram>(
            this IApplicationBuilder app)
        {
            var clientAssemblyInServerBinDir = typeof(TProgram).Assembly;
            return app.UseLocalBlazor(new BlazorOptions
            {
                ClientAssemblyPath = clientAssemblyInServerBinDir.Location,
            });
        }
        /// <summary>
        /// Configures the middleware pipeline to work with Blazor.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/>.</param>
        /// <param name="options">Options to configure the middleware.</param>
        /// <returns>The <see cref="IApplicationBuilder"/> with configured Blazor.</returns>
        public static IApplicationBuilder UseLocalBlazor(
            this IApplicationBuilder app,
            BlazorOptions options)
        {
            // TODO: Make the .blazor.config file contents sane
            // Currently the items in it are bizarre and don't relate to their purpose,
            // hence all the path manipulation here. We shouldn't be hardcoding 'dist' here either.
            var env = (IHostingEnvironment)app.ApplicationServices.GetService(typeof(IHostingEnvironment));
            var config = BlazorConfig.Read(options.ClientAssemblyPath);
            // First, match the request against files in the client app dist directory
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(config.DistPath),
                ContentTypeProvider = CreateContentTypeProvider(config.EnableDebugging),
                OnPrepareResponse = SetCacheHeaders
            });
            // * Before publishing, we serve the wwwroot files directly from source
            //   (and don't require them to be copied into dist).
            //   In this case, WebRootPath will be nonempty if that directory exists.
            // * After publishing, the wwwroot files are already copied to 'dist' and
            //   will be served by the above middleware, so we do nothing here.
            //   In this case, WebRootPath will be empty (the publish process sets this).
            if (!string.IsNullOrEmpty(config.WebRootPath))
            {
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(config.WebRootPath),
                    OnPrepareResponse = SetCacheHeaders
                });
            }
            // Accept debugger connections
            if (config.EnableDebugging)
            {
                // Disable MonoDebugProxy, since it require me to maintain copy of Blazor code
                // app.UseMonoDebugProxy();
            }
            // Finally, use SPA fallback routing (serve default page for anything else,
            // excluding /_framework/*)
            app.MapWhen(IsNotFrameworkDir, childAppBuilder =>
            {
                var indexHtmlPath = FindIndexHtmlFile(config);
                var indexHtmlStaticFileOptions = string.IsNullOrEmpty(indexHtmlPath)
                    ? null : new StaticFileOptions
                    {
                        FileProvider = new PhysicalFileProvider(Path.GetDirectoryName(indexHtmlPath)),
                        OnPrepareResponse = SetCacheHeaders
                    };
                childAppBuilder.UseSpa(spa =>
                {
                    spa.Options.DefaultPageStaticFileOptions = indexHtmlStaticFileOptions;
                });
            });
            return app;
        }
        private static string FindIndexHtmlFile(BlazorConfig config)
        {
            // Before publishing, the client project may have a wwwroot directory.
            // If so, and if it contains index.html, use that.
            if (!string.IsNullOrEmpty(config.WebRootPath))
            {
                var wwwrootIndexHtmlPath = Path.Combine(config.WebRootPath, "index.html");
                if (File.Exists(wwwrootIndexHtmlPath))
                {
                    return wwwrootIndexHtmlPath;
                }
            }
            // After publishing, the client project won't have a wwwroot directory.
            // The contents from that dir will have been copied to "dist" during publish.
            // So if "dist/index.html" now exists, use that.
            var distIndexHtmlPath = Path.Combine(config.DistPath, "index.html");
            if (File.Exists(distIndexHtmlPath))
            {
                return distIndexHtmlPath;
            }
            // Since there's no index.html, we'll use the default DefaultPageStaticFileOptions,
            // hence we'll look for index.html in the host server app's wwwroot.
            return null;
        }
        private static void SetCacheHeaders(StaticFileResponseContext ctx)
        {
            // By setting "Cache-Control: no-cache", we're allowing the browser to store
            // a cached copy of the response, but telling it that it must check with the
            // server for modifications (based on Etag) before using that cached copy.
            // Longer term, we should generate URLs based on content hashes (at least
            // for published apps) so that the browser doesn't need to make any requests
            // for unchanged files.
            var headers = ctx.Context.Response.GetTypedHeaders();
            if (headers.CacheControl == null)
            {
                headers.CacheControl = new CacheControlHeaderValue
                {
                    NoCache = true
                };
            }
        }
        private static bool IsNotFrameworkDir(HttpContext context)
            => !context.Request.Path.StartsWithSegments("/_framework");
        private static IContentTypeProvider CreateContentTypeProvider(bool enableDebugging)
        {
            var result = new FileExtensionContentTypeProvider();
            result.Mappings.Add(".dll", MediaTypeNames.Application.Octet);
            result.Mappings.Add(".mem", MediaTypeNames.Application.Octet);
            if (enableDebugging)
            {
                result.Mappings.Add(".pdb", MediaTypeNames.Application.Octet);
            }
            return result;
        }
        internal class BlazorConfig
        {
            private BlazorConfig(string assemblyPath)
            {
                // TODO: Instead of assuming the lines are in a specific order, either JSON-encode
                // the whole thing, or at least give the lines key prefixes (e.g., "reload:<someuri>")
                // so we're not dependent on order and all lines being present.
                var configFilePath = Path.ChangeExtension(assemblyPath, ".blazor.config");
                var configLines = File.ReadLines(configFilePath).ToList();
                this.SourceMSBuildPath = configLines[0];
                if (this.SourceMSBuildPath == ".")
                {
                    this.SourceMSBuildPath = assemblyPath;
                }
                var sourceMsBuildDir = Path.GetDirectoryName(this.SourceMSBuildPath);
                this.SourceOutputAssemblyPath = Path.Combine(sourceMsBuildDir, configLines[1]);
                var webRootPath = Path.Combine(sourceMsBuildDir, "wwwroot");
                if (Directory.Exists(webRootPath))
                {
                    this.WebRootPath = webRootPath;
                }
                this.EnableDebugging = configLines.Contains("debug:true", StringComparer.Ordinal);
            }
            public string SourceMSBuildPath { get; }
            public string SourceOutputAssemblyPath { get; }
            public string WebRootPath { get; }
            public string DistPath
                => Path.Combine(Path.GetDirectoryName(this.SourceOutputAssemblyPath), "dist");
            public bool EnableDebugging { get; }
            public static BlazorConfig Read(string assemblyPath)
                => new BlazorConfig(assemblyPath);
        }
    }
}
Usage:
// Use this insted of standard 'UseBlazor'
app.UseLocalBlazor<BlazorApp.Program>();
