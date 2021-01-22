    struct Test
    {
        public Test(int value)
        {
           this.i = value;
        }
        int i;
        void Mutate(int newValue) {
             this = new Test(newValue); // This wouldn't work with classes
        }
    }
    ///
    {
        Test test = new Test();
        test.i = 3;
        Console.WriteLine(test.i); // Writes 3
        test.Mutate(4); 
        Console.WriteLine(test.i); // Writes 4
