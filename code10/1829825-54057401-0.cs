    public class Startup {
        public void Configure(IApplicationBuilder app) {
            // other configure code
            var opts = new FileServerOptions {
                RequestPath = "/public",
                FileProvider = new PhysicalFileProvider(@"c:/public_assets/photos")
            };
            app.UseFileServer(opts);
        }
    }
