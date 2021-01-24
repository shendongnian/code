      public void Rename(string root_path){
                var dirs = Directory.EnumerateDirectories(root_path);
                foreach(var folder in dirs){
            if(folder.contains("spcefic_word")
                   // voila! rename
         Rename(folder);
        
        }
