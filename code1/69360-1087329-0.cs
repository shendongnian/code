    struct MyStruct
    {
        private readonly int m_Age;
        private readonly string m_LastName;
        private readonly string m_FirstName;
    
        public int Age { get { return m_Age; } }
        public string LastName { get { return m_LastName; } }
        public string FirstName { get { return m_FirstName; } }
    
        public MyStruct( int age, string last, string first )
        {
            m_Age = age;
            m_LastName = last;
            m_FirstName = first;
        }
    }
    
    class StructReflection
    {
        public static void Main(string[] args)
        {
            var theStruct = new MyStruct( 40, "Smith", "John" );
            PrintStructProperties( theStruct );
        }
    
        public static void PrintStructProperties( MyStruct s )
        {
            // NOTE: This code will not handle indexer properties...
            var publicProperties = s.GetType().GetProperties();
            foreach (var prop in publicProperties)
                Console.WriteLine( "{0} = {1}", prop.Name, prop.GetValue( s, null ) );
        }
    }
