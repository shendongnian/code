    class NoTfs : ITfs
    {
      public bool checkout(string filename)
      {
        //TFS not installed so checking out is impossible
        return false;
      }
    }
