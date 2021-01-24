    //Triangle Area = 1/2(base x height)
    Console.Writeline("Please write the b value of the triangle:")`enter code here`
    double bSide = double.Parse(Console.ReadLine());
    Console.write("Please write the h value of your triangle:")
    double hSide = double.Parse(Console.ReadLine());
    
    double area = (bSide * hSide) / 2;
    Console.Writeline("The area of your triangle is:{0}", area.ToString());
    Console.ReadLine();
