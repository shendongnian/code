    //prints out all the disarium numbers lower than a user defined number
    static void Main(string[] args)
    {
        //assigns the variables
        string number , strI;
        double calculation;
        //asks the user for string number
        Console.WriteLine("Give a number between 10 and 1.000.000. This program will tell you all the disarium numbers lower than the given number.");
        number = Console.ReadLine();
        Console.WriteLine("");
        //calcules all the disarium numbers lower than string number
        for (Int64 I = 10;I < Convert.ToInt64(number);I++)
        {
            calculation = 0;
            strI = Convert.ToString(I);
            for (int i = 0; i < strI.Length; i++)
            {
                calculation += Math.Pow(Convert.ToDouble(strI[i].ToString()), Convert.ToDouble(i) + 1.0);
            }
            //Prints out all the desarium numbers below string number
            if (Convert.ToInt64(calculation) == I)
            {
                Console.WriteLine(I + " is a disarium number.");
            }
        }
    }
