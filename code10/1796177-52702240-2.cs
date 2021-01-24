        var xx = new DateTime(2018,10,8,13,19,50);
        while (true)
        {
            // If DateTime.Now exceeds xx 
            if (DateTime.Now >= xx) {
                // bee..eep
                Console.Beep();
                // and break the loop  
                break;
            }
        }
