    extern alias asm1;
    extern alias asm2;
    
    namespace Client
    {
        class Program
        {
            static void Main(string[] args)
            {
                asm1.MyNs.MyClass mc1 = null;
                asm2.MyNs.MyClass mc2 = null;
            }
        }
    }
