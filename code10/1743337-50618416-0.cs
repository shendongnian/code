    if (Console.ReadLine() == "y")
                {
                    return true;
                }
                else if (Console.ReadLine() == "n")
                {
                    return false;
                }
                else {
                  throw new Exception("only y and n allowed...");
                }
