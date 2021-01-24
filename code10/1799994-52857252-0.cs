    public void printInfo()
    {
        Console.WriteLine("\r\nStudent Record: ");
        Console.WriteLine("\tName     : " + this.name);
        Console.WriteLine("\tRollNo   : " + this.rollno);
        Console.WriteLine("\tAge      : " + this.age);
        
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of passengers");
        x=int.Parse(Console.ReadLine());
        Customer[] S = new Customer[x];
        for (int i = 0; i < x; i++)
        {
            S[i] = new Customer();
            S[i].SetInfo();
        }
        for (int j = 0; j < x; j++)
        {
            S[j].printInfo();
        }
     
        Console.ReadKey();
    }
