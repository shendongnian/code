            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            sb2 = sb1;
            sb1.Append("hello");
            sb1.Append("world");
            Console.WriteLine(sb2);
            // Output Hello World
            // value Type
            int x=100;            
            int y = x;
            x = 30;            
            Console.WriteLine(y);
            // Out put 100 instead of 30
