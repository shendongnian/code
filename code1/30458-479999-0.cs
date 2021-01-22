    private void Sort( string propertyName )
    {
       List<MyClass> myCurClass = ...
    
       myCurClass.Sort(delegate( MyClass left, MyClass right ){
    
          PropertyInfo lp = typeof(MyClass).GetProperty (propertyName);
    
          Comparer.Default.Compare (pi.GetValue(left), pi.GetValue(right));
    
    
       });
    }
