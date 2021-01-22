            using (Stream stream = File.OpenRead(file))
               {
                   try
                   {
                       using (Image sourceImage = Image.FromStream(stream, false, false))
                       {
                         
                       }
                   }
                   catch (Exception x)
                   {
                       if (x.Message.Contains("not valid"))
                       {
                         Console.Write("This is not a Image.");
                       }
                       
                   }
               }
