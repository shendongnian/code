       public void Do(string x, string y)
       {
          lock (fileInput)
          {
             fileInput.Replace(x, y);
          }
       }
