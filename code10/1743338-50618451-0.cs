        static public bool askBool(string question)
        {
            bool boolToReturn = false;
            try
            {
                Console.Write(question);
                while (true)
                {
                    string ans = Console.ReadLine();
                    if (ans != null && ans == "y")
                    {
                        boolToReturn = true;
                        break;
                    }
                    else if ( ans != null && ans == "n")
                    {
                        boolToReturn = false;
                        break;
                    }
                    else
                    {
                        Console.Write("Only y or n Allowed");
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return boolToReturn;
        }
