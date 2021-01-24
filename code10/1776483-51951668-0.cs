    string[] lines = System.IO.File.ReadAllLines(@"test.txt");
    Random rd = new Random();
    int ball = rd.Next(0, lines.Length); // you can use the Length of the array to avoid jumping out of bounds
    Console.WriteLine("Random line at line: " + ball);
    Console.WriteLine(lines[ball]); // access here a line using your random number
