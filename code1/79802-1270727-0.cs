    // selected characters
    string chars = "2346789ABCDEFGHJKLMNPQRTUVWXYZabcdefghjkmnpqrtuvwxyz";
    // create random generator
    Random rnd = new Random();
    string name;
    do {
       // create name
       name = string.Empty;
       while (name.Length < 5) {
          name += chars.Substring(rnd.Next(chars.Length), 1);
       }
       // add extension
       name += ".txt";
       // check against files in the folder
    } while (File.Exists(folderPath + name))
