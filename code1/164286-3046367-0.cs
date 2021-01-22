    public DisplayDialog static Show()
    {
      var result = new DisplayDialog; //possibly cache instance of the dialog if needed, but this could be tricky
      result.ShowDialog(); 
      return result;
    }
