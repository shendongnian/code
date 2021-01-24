    private async static Task CropImage()
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync("https://assets-cdn.github.com/images/modules/logos_page/GitHub-Mark.png")
                .ConfigureAwait(false);
    
            using (var inputStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
            {
                using (var image = Image.Load(inputStream))
                {
                    var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "foo.png");
    
                    image.Clone(
                        ctx => ctx.Crop(560, 300)).Save(path);
                }
            }
        }
    }
