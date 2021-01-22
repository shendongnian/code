    
      private void FileList_OnDrop(object sender, DragEventArgs e)
      {
        var dropped = ((string[])e.Data.GetData(DataFormats.FileDrop));
        var files = dropped.ToList();
        if (!files.Any())
          return;
        foreach (string drop in dropped)
          if (Directory.Exists(drop))
            files.AddRange(Directory.GetFiles(drop, "*.dwg", SearchOption.AllDirectories));
        foreach (string file in files)
        {
          if (!fileList.Contains(file) && file.ToLower().EndsWith(".dwg"))
            fileList.Add(file);
        }
      }
