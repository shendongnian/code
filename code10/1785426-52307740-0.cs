                     string pdflocation = "D:\\";
                      string fileName = "softcore.pdf";
    
                      // put your base64 string converted from online platform here instead of V
                      var base64String = V;
    
                      int mod4 = base64String.Length % 4;
                      // as of my research this mod4 will be greater than 0 if the base 64 string is corrupted
                      if (mod4 > 0)
                      {
                            base64String += new string('=', 4 - mod4);
                      }
                      pdflocation = pdflocation + fileName;
    
                      byte[] data = Convert.FromBase64String(base64String);
    
                      using (FileStream stream = System.IO.File.Create(pdflocation))
                      {
                            stream.Write(data, 0, data.Length);
                      }
