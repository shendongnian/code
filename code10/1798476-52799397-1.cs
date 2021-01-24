    foreach (var file in openFileDialog.FileNames)
    {
       var name = Path.GetFileName(file);
       var path = Path.GetDirectoryName(file);
       var newPath = Path.Combine(path, "Originals");
       var newName = $"{Path.GetFileNameWithoutExtension(name)}.jpg";
    
       Directory.CreateDirectory(newPath);
    
       var newFullPath = Path.Combine(newPath, name);
       // why do anything fancy when you just want to move it
       File.Move(file, newFullPath);
    
       // lets open that file from there, so we don't accidentally cause the same 
       // problem again, then save it
       using (var image = Image.FromFile(newFullPath))
          image.Save(Path.Combine(path, newName), ImageFormat.Jpeg);  
    }
