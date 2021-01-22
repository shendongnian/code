      try
      {
          using (ZipFile zip = new ZipFile(args[0], System.Console.Out))
          {
              zip.AddDirectory(args[1]); // recurses subdirectories
              zip.Save();
          }
      }
      catch (System.Exception ex1)
      {
          System.Console.Error.WriteLine("exception: " + ex1);
      }
