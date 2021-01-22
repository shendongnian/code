    public MyClass(MyOtherClass inputObject): this(inputObject.ID, GetHelperText(inputObject) {}
    
    private static string GetHelperText(MyOtherClass o)
    {
       using (var helper = o.CreateHelper())
          return helper.Text;
    }
