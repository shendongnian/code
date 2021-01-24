app.UseStaticFiles(new StaticFileOptions
{
     FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Assets")),
            RequestPath = "/Assets"
});
