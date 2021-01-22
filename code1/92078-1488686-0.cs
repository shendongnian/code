    string[] fileEntries = 
    Array.FindAll<string>(System.IO.Directory.GetFiles(pathName, "*.xml"), 
                new Predicate<string>(delegate(string s)
                {
                    return System.IO.Path.GetExtension(s) == ".xml";
                }));
