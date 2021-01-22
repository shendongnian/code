    Console.WriteLine("Here are a list of colors:");
    foreach(Color.clr item in Enum.GetValues(typeof(Color.clr)))
    {
        Console.WriteLine(string.Format("{0} - {1}",(int)item,item.ToString()));
    }
    Console.WriteLine("Please choose your color");
    string colorInput = Console.ReadLine();
    int colorValue = 0;
    if(!int.TryParse(colorInput, out colorValue))
    {
            Console.WriteLine(string.Format("{0} is not a valid number",colorInput));
            return;
    }
    
    // This will give an error if they've typed a number that wasn't listed
    // So need to add a bit of checking here
    Color.clr tempColor = (Color.clr)colorValue;
    // Your code here
