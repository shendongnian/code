    TagLib.File target = null;
            if (!string.IsNullOrEmpty(location) && File.Exists(location))
            {
                 target = TagLib.File.Create(location);
            }
            else
            {
                //log or print a warning 
            }
