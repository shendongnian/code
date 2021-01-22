    class SomeControl
    {
    private string _SomeProperty  ;
    public string SomeProperty 
    {
      if ( _SomeProperty == null ) 
       return (string)Session [ "SomeProperty" ] ;
     else 
       return _SomeProperty ; 
    }
    }
