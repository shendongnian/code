       class BaseType
       {
          public virtual T LastRequest { get {...} }
       }
    
       class DerivedTypeStrategy1
       {
          /// get or set the value returned by the LastRequest property.
          public bool T LastRequestValue { get; set; }
    
          public override T LastRequest { get { return LastRequestValue; } }
       }
    
       class DerivedTypeStrategy2
       {
          /// set the value returned by the LastRequest property.
          public bool SetLastRequest( T value ) { this._x = value; }
    
          public override T LastRequest { get { return _x; } }
    
          private bool _x;
       }
