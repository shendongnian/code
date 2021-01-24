    switch (Player1)
    {
        case "Rock":
            switch (Player2)
            {
                case "Rock":
                    Console.WriteLine("Draw");
                    break;
                case "Scissors":
                    Console.WriteLine("Win Player1");
                    break;
                case "Paper":
                    Console.WriteLine("Win Player2");
                    break;
            }
            switch (Player1)
            {
                case "Scissors":
                    switch (Player2)
                    {
                        case "Rock":
                            Console.WriteLine("Win Player2");
                            break;
                        case "Scissors":
                            Console.WriteLine("Draw");
                            break;
                        case "Paper":
                            Console.WriteLine("Win Player1");
                            break;
                    }
                    switch (Player1)
                    {
                        case "Paper":
                            switch (Player2)
                            {
                                case "Rock":                       
                                    Console.WriteLine("Win Player1");
                                    break;
                                case "Scissors":
                                    Console.WriteLine("Win Player2");
                                    break;
                                case "Paper":
                                    Console.WriteLine("Draw");
                                    break;
                                }
                        break;
                    }
                break;
             }
        break;    
    }
