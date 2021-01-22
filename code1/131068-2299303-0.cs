    public BaseClass
    {
       public BaseClass( String s ) { ... }
       public static void doIt ( String s ) { ... }
    }
    
    public SubClass extends BaseClass
    {
       public SubClass( String s )  { ... }
       public static void doIt ( String s ) { ... }
    }
    public SubClass2 extends BaseClass
    {
    }
    new SubClass( "hello" );
    SubClass.doIt( "hello" ); 
    new SubClass2( "hello" ); // NOK
    SubClass2.doIt( "hello" ); // NOK
