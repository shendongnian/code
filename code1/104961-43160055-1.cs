    // Declare Delegates
        public delegate void DisplayNamme(string name);
        class Program
        {
           public static void getName(string name)
            {
                Console.WriteLine(name);
            }
           public static void ShowName(DisplayNamme dn, string name)
            {
            // callback method calling. We can call it in two ways. 
               dn(name);
              // or explicitly
                dn.Invoke(name);
        }
          static void Main(string[] args)
            {
                DisplayNamme delDN = new DisplayNamme(Program.getName);
                Program.ShowName(delDN, "CallBack");
                Console.ReadLine();
            }
        }
