            string input = "Old Macdonald had a farm and on";
            List<string> words = input.Split(" ".ToCharArray()).ToList();
            string finalString = "";
            int indexOfMac = words.IndexOf("Macdonald");
            int indexOfFarm = words.IndexOf("farm");
            if (indexOfFarm != -1 && indexOfMac != -1 &&  //if word is not there in string, index will be '-1' 
                indexOfMac < indexOfFarm)  //checking if 'macdonald' comes before 'farm' or not
                
            {
                //looping from Macdonald + 1 to farm, and make final string
                for(int i = indexOfMac + 1; i <= indexOfFarm; i++)
                {
                    finalString += words[i] + " ";
                }
            }
            else
            {
                finalString = "No farms for you";
            }
            Console.WriteLine(finalString);
