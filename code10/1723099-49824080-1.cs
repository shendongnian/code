    class Question
    {
        public void MyMethod(int x = 1) {}
        public void MyMethod(int x = 1, int y = 2) {}
    }
    
    class Test
    {
        static void Main()
        {
            // Ambiguous
            new Question().MyMethod();
            // Unambiguous
            new Question().MyMethod(0);
        }        
    }
