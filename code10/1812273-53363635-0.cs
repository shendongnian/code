     string str;
        var index = 1;
        int strintoA = 0;
        bool isNegative = false;
     
        //ASCII list of numbers and signs
        List<int> allowedValues = new List<int> { 43, 45, 48, 49, 50, 51, 52, 53, 54, 55, 56, 
        57 };
        bool flag = false;
    
        while (!flag)
        {
            Console.WriteLine("Enter a Number : ");
    
            str = Console.ReadLine();
    
            if (str.Count(item => allowedValues.Contains((int)item)) == str.Count())
            {
                foreach (var item in str.Reverse())
                {               
                    if (item != 43 && item != 45)
                    {
                        strintoA += index * (item - 48);
                        index = index * 10;
                    }
                    else if(item == 45)
                    {
                        isNegative = true;
                    }
                }
                if(isNegative)
                {
                    strintoA *= -1;
                }
                
                Console.WriteLine("Entered String: " + str + " is a Number!");
                flag = true;
            }
            else
            {
                Console.WriteLine("Please Enter Numbers Only.");
            }
        }
        Console.ReadKey();
    }
