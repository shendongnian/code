    public void RequestForUserName()
    {
        Console.WriteLine("please insert a name for new student.");
        var cr = Console.ReadLine();
        if (!string.IsNullOrEmpty(cr))
        {
            student.add(cr);
        }
        else
        {
        //do as you wish.. like default name
        }
    }
