    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            struct SimpleStruct
            {
                int a;
                public SimpleStruct(int a)
                {
                    this.a = a;
                }
            }
            enum SimpleEnum
            {
                a = 1,
                b = 2,
            }
    
            static void Main(string[] args)
            {
                SimpleStruct tp = new SimpleStruct(2);
    
                object ob = tp;
                if (ob != null)
                {
                    Console.WriteLine("struct is an object : " + ob);
                    tp = (SimpleStruct)ob;
                }
    
                SimpleEnum tp2 = SimpleEnum.a;
                ob = tp2;
                if (ob != null)
                {
                    Console.WriteLine("enum is an object : " + ob);
                    tp2 = (SimpleEnum)ob;
                }
                Console.ReadKey();
            }
        }
    }
