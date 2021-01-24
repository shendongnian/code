    public Image FindImageByPath(string path) // eg: MyProject.ImageFolder.MyImage.png
    {
         using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path,))
         return Image.FromStream(stream);
    }
