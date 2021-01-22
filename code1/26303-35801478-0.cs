         string fileName = "6d294041-34d1-4c66-a04c-261a6d9aee17.jpeg";
         string deletePath= "/images/uploads/";
         if (!string.IsNullOrEmpty(fileName ))
            {
                // Append the name of the file to previous image.
                deletePath += fileName ;
                if (File.Exists(HttpContext.Current.Server.MapPath(deletePath)))
                {
                    // deletevprevious image
                    File.Delete(HttpContext.Current.Server.MapPath(deletePath));
                }
            }
