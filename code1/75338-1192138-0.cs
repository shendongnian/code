    namespace test
    {
       using BlockShortcuts;
       class MyTest
       {
            public static void Main(string[] args)
            {
               DisableKeys dk = new DisableKeys();
               dk.DisableKeyboardHook();
            }
       }
     }
