    decimal x = 123.45M;
    Console.WriteLine(x.ToString("0"));  // Output: 123   
    Console.WriteLine(x.ToString("0.0"));  // Output: 123.5   <- note there is rounding
    Console.WriteLine(x.ToString("0.00"));  // Output: 123.45
    Console.WriteLine(x.ToString("0.000"));  // Output: 123.450
    Console.WriteLine(x.ToString("#.###"));  // Output: 123.45
