    public class MyBaseEnum
    {
        public static readonly MyBaseEnum A = new MyBaseEnum( 1 );
        public static readonly MyBaseEnum B = new MyBaseEnum( 2 );
        public static readonly MyBaseEnum C = new MyBaseEnum( 3 );
        public int InternalValue { get; protected set; }
        protected MyBaseEnum( int internalValue )
        {
            this.InternalValue = internalValue;
        }
    }
    public class MyEnum : MyBaseEnum
    {
        public static readonly MyEnum D = new MyEnum( 4 );
        public static readonly MyEnum E = new MyEnum( 5 );
        protected MyEnum( int internalValue ) : base( internalValue )
        {
            // Nothing
        }
    }
    [TestMethod]
    public void EnumTest()
    {
        this.DoSomethingMeaningful( MyEnum.A );
    }
    private void DoSomethingMeaningful( MyBaseEnum enumValue )
    {
        // ...
        if( enumValue == MyEnum.A ) { /* ... */ }
        else if (enumValue == MyEnum.B) { /* ... */ }
        // ...
    }
