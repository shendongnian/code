    public interface Foo {
      string Name {get;set;}
    }
    
    pubilc class Bar : Foo {
    #region Foo implementation
      public string Name {get{return UserName;} set{UserName = value;}}
    #endregion //Foo implementation
      public string UserName {get; set;}
    }
