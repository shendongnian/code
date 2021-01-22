    static private void test()
    {
        for (int i = 0; i <= 0xffff; ++i)
        {
            char c = (char) i;
            
            if (Char.IsDigit( c) != Char.IsNumber( c)) {
                Console.WriteLine( "Char value {0:x} IsDigit() = {1}, IsNumber() = {2}", i, Char.IsDigit( c), Char.IsNumber( c));
            }
        }
    }
