     bool InUse(string path)
     {
          try
          {
              using (File.OpenRead(path))return true;
          }
          catch {}
          return false;
     }
