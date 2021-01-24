    static int GetNumber(){
        Console.WriteLine("Enter a number");
        string entry = Console.ReadLine();
        int num;
        bool res = int.TryParse(entry, out num);
        if (res == true){
            return num;
        }
        
        Console.WriteLine("You did not enter a proper number");
        return GetNumber();        
    }
