    static void Driver()
    {
        switch (userChoice)
        {
            case 1: // if user picks a 1, the count is deincremented
                if(myObjectOfCounterClass.CanSubtractCount)
                {
                     myObjectOfCounterClass.SubtractCount();
                }
                else
                {
                     // Write a message to the user?
                }
             break;
             // case 2, case 3 etc.
         }
    }
