    // add the reference to the newly generated dll
    use MyEnums ; 
    class Program
    {
        static void Main ()
        {
            Array values = Enum.GetValues ( typeof ( EnumeratedTypes.MyEnum ) );
            foreach (EnumeratedTypes.MyEnum val in values)
            {
                Console.WriteLine ( String.Format ( "{0}: {1}",
                        Enum.GetName ( typeof ( EnumeratedTypes.MyEnum ), val ),
                        val ) );
            }
            Console.WriteLine ( "Hit enter to exit " );
            Console.ReadLine ();
        } //eof Main 
    } //eof Program
 
