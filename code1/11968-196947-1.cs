    public MyClass(){
      var properties = this.GetType().GetProperties();
      foreach(PropertyInfo p in properties){
        p.SetValue(this, DoStuff(p.Name), new object[0]);
      }
    }
