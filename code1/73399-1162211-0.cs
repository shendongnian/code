        Console.WriteLine("Here are a list of colors:");
        foreach(Color.clr item in Enum.GetValues(typeof(Color.clr)))
        {
            Console.WriteLine(string.Format("{0} - {1}",(int)item,item.ToString()));
        }
        Console.WriteLine("Please choose your color");
