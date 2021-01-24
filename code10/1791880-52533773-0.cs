    public string[] getDBDirectory() {
      //Directory db; //no need
      if (!Directory.Exists(itemFolder)) {
         Console.WriteLine("Couldn't find directory.. is it created?");
         return null;
      } else {
        return Directory.GetDirectories(itemFolder);
      }
    }
