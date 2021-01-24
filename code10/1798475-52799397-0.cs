    foreach (var file in openFileDialog.FileNames)
    {
       var name = Path.GetFileName(file);
       var path = Path.GetDirectoryName(file);
       var newPath = Path.Combine(path, "Originals");
       var newName = $"{Path.GetFileNameWithoutExtension(name)}.jpg";
    
       Directory.CreateDirectory(newPath);
    
       using (var image = Image.FromFile(file))
       {
          // there is no need to try to work out the format
          // you just need to save it to the new path
          image.Save(Path.Combine(newPath, name));
          image.Save(Path.Combine(path, newName), ImageFormat.Jpeg);
       }
    }
