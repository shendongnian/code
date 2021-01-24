    Color c = (Color) (new Random()).Next(0, 3);
    switch (c)
    {
        //Value of "c" is red
        case Color.Red:
           Console.WriteLine("Red!");
           break;
        //Value of "c" is green
        case Color.Green:
           Console.WriteLine("Green!");
           break;
        //Value of "c" is blue
        case Color.Blue:
           Console.WriteLine("Blue!");   
           break;
        //"c" is not red, green, or blue, so we default our message to say the color is unknown!
        default:
           Console.WriteLine("The color is not known.");
           break;   
    }
