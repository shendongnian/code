    if (file != null)
            {
                byte[] imageBytes;
                var FileImage = new Image();
    
                string base64;
                using (var fs = new FileStream(file.FilePath, FileMode.Open, FileAccess.Read))
                {
                    var buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, (int)fs.Length);
                    base64 = Convert.ToBase64String(buffer);
                }
    
                imageBytes = Convert.FromBase64String(base64); 
                File.WriteAllBytes(filename, imageBytes);
                var bitmap = new Image { Source = filename};
    
                imgViewer2.Source = bitmap.Source;
                
