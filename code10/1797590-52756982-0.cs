    case "A":
    {
        userChoice = ReadFromConsole("Subject");
        switch (userChoice.ToUpper())
            case "A"/*ADD_SUBJECT*/:
            {
                AddSubject();
                break;
            }
            case "B"/*EDIT_SUBJECT*/:
            {
                Console.WriteLine("edit subject");
                break;
            }
            case "C"/*DELETE_SUBJECT*/:
            {
                Console.WriteLine("delete subject");
                break;
            }
        }
        break;
    }
