    public void MyFunction(MyObject obj)
    {
      obj.DoSomething();
      SpecializedObject specialized = obj as SpecializedObject;
      if(specialized!=null)
      {
        specialized.DoSthSpecial();
      }
    }
