            if ( iLvl >= 1 || iLvl <= 4)       // teir 8
            {
                preRoll = obj.Next(5, 9);
            }
            else if (iLvl >= 5 || iLvl <= 10)  // teir 7
            {
                preRoll = obj.Next(10, 19);
            }
            else if (iLvl >= 11 || iLvl <= 17)  // teir 6
            {
                preRoll = obj.Next(20, 29);
            }
