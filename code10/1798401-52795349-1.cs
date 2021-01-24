     //Triangle Area = 1/2(base x height)
            Console.WriteLine("Please write the b value of the triangle:");
            double bSide = double.Parse(Console.ReadLine());
            Console.Write("Please write the h value of your triangle:");
            double hSide = double.Parse(Console.ReadLine());
            double area = (bSide * hSide) / 2;
            Console.WriteLine("The area of your triangle is:" + Convert.ToString(area));
            Console.ReadLine();
