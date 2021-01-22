    using System;
    
    class Test
    {
        static void Main(string[] args)
        {
            // Clone the whole array
            string[] args2 = (string[]) args.Clone();
            
            // Copy the five elements with indexes 2-6
            // from args into args3, stating from
            // index 2 of args3.
            string[] args3 = new string[5];
            Array.Copy(args, 2, args3, 0, 5);
            
            // Copy whole of args into args4, starting from
            // index 2 (of args4)
            string[] args4 = new string[args.Length+2];
            args.CopyTo(args4, 2);
        }
    }
