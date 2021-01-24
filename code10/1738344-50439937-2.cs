            string str = "1 0 1 0 1 " +
                         "0 0 0 0 1 " +
                         "0 1 1 1 0 " +
                         "1 0 1 0 1 " +
                         "1 1 1 1 1";
            string[] stringArray = str.Split(' '); // split strings into string array using "space" as split
            bool[,] boolArray = new bool[5, 5];
            int counter = 0;  // counter for iterating through stringArray
            int counterMax = stringArray.Length - 1; // set max for counter to stop index out of range
            for (int j = 0; j < 5; j++) // Y axis
            {
                for (int i = 0; i < 5; i++) // X axis
                {
                    if (stringArray[counter] == "0")
                    {
                        boolArray[j, i] = false;
                    }
                    else
                    {
                        boolArray[j, i] = true;
                    }
                    if (counter < counterMax)
                    {
                        counter++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
