    delegate void SomeMethod();
    
    
    class Test
            {
                static void Main()
                {
                    List<SomeMethod> word = new List<SomeMethod>();
                    word.Add(new GroupOne().ExpressWords());
                    word.Add(new GroupTwo().ExpressWords());
        
                    foreach (SomeMethod del in word)
                    {
                          del();
                    }
                   Console.ReadKey(true);
                }
            }
