    string[] validanswers = {
                "a",
                "b",
                ...
            }
            
            
            bool isValid = false;
            foreach (var validanswer in validanswers)
            {
                if(check == validanswer)
                {
                     isValid = true;
                    break;
                }
            }
            
            if(isValid)
                Console.WriteLine("The input is valid");
            else
                Console.WriteLine("The input is invalid");
