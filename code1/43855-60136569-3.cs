    DateTime first = new DateTime(1992,02,02,20,50,1);
    DateTime second = new DateTime(1992, 02, 02, 20, 50, 2);
          
    var compare = first.Date.CompareTo(second.Date);
    switch (compare)
    {
        case 1:
            Console.WriteLine("this instance is later than value.");
            break;
        case 0:
            Console.WriteLine("this instance is the same as value.");
            break;
        default:
            Console.WriteLine("this instance is earlier than value.");
            break;
    }
