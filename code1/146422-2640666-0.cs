    public void SomeMethod(object obj)
    {
      ITag it = obj as ITag;
      
      if(it != null)
      {
        it.SomeProperty = "SomeValue";
        it.DoSomthingWithTag();
      }
    }
