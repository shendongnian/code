    Point pt = new Point();
    if(Int32.TryParse(userInput, out pt.x))
    {
         Console.WriteLine("x = {0}", pt.x);
         Console.WriteLine("x must be a public variable! Otherwise, this won't compile.");
    }
