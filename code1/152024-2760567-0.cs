    using System;
        
    namespace ConsoleApplication1
    {
        class Program
        {
            struct Params
            {
                public double abc, sdc;
            };
    
            static void Main(string[] args)
            {
                string s = "(params (abc 1.3)(sdc 2.0))";
                Params p = new Params();
                object pbox = (object)p; // structs must be boxed for SetValue() to work
    
                string[] arr = s.Substring(8).Replace(")", "").Split(new char[] { ' ', '(', }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < arr.Length; i+=2)
                    typeof(Params).GetField(arr[i]).SetValue(pbox, double.Parse(arr[i + 1]));
                p = (Params)pbox;
                Console.WriteLine("p.abc={0} p.sdc={1}", p.abc, p.sdc);
            }
        }
    }
