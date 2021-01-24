    void sw()
    {
            string x = "f";
            switch (x)  // Compile skips directly to  case "f":
            {
                case "a":
                    Console.WriteLine(x);
                    break;
                case "b":
                    Console.WriteLine(x);
                    break;
                case "f":
                    Console.WriteLine(x);
                    break;
            }
    }
