    public void GetList(ref object list)
    {
      String[] dummy = { "1" };
      Array.Resize(ref dummy, 3);
      list = dummy;
    }
