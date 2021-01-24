            double x,y,z,v;
            Console.Write("x=");
            double.TryParse(Console.ReadLine(), out x);
            Console.Write("y=");
            double.TryParse(Console.ReadLine(), out y);
            Console.Write("z=");
            double.TryParse(Console.ReadLine(), out z);
            v=(1+Math.Pow(Math.Sin(x+y)))/
            Math.Abs(x-2*y/(1+x*x*y*y))*Math.Pow(x,Math.Abs(y))+
            Math.Pow(Math.Cos(Math.Atan(1/z)),2);
            Console.Write("v="+v);
            Console.ReadKey();
