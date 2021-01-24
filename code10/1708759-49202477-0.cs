    string image = Constants.ImageName;
    if (image != "NONE")
    {
        Directory.CreateDirectory(Path.GetDirectoryName(DestinationDir + "\\" + image));
        File.Copy(SourceDir + "\\" + image, DestinationDir + "\\" + image, true);
    }
