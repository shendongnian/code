    string _pathForImages = "c:\inetpub\wwwroot\NewFolder\ExistingFolder\Images\";
       try
        {
            string[] f = Directory.GetFiles(_pathForImages);
            int k = f.Length;
            string _pathForImages_dest = "c:\inetpub\wwwroot\NewFolder\NewFolder1\Images\";
            for (int i = 0; i < k; i++)
            {
                var kl = f[i].Split('\\');
                string fname = kl[kl.Length - 1];
                string j = _pathForImages_test;
                System.IO.File.Copy(f[i], _pathForImages_dest + fname,true);
                
               
            }
        }
        catch (Exception ex)
        {
          
        }
