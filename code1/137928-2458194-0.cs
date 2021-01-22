     try
        {
            string[] f = Directory.GetFiles(_pathForImages);
            int k = f.Length;
            for (int i = 0; i < k; i++)
            {
                var kl = f[i].Split('\\');
                string fname = kl[kl.Length - 1];
                string j = _pathForImages_test;
                System.IO.File.Copy(f[i], _pathForImages_test + fname);
                
               
            }
        }
        catch (Exception ex)
        {
          
        }
