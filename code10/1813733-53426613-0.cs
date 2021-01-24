            List<string> str = new List<string> {"1", "3", "1", "2", "3", "43", "23", "54", "3"," "4 };
            List<string> foundstr = new List<string> { };
            foreach (string check in str)
            {
                bool found = false;
                //going through every single item in the list and checking if it is found in there
                for (int i = 0; i < foundstr.Count; i++)
                {
                //if found then make found(bool) true so we don't put it in the list
                    if(check == foundstr[i])
                    {
                        found = true;
                    }  
                }
                //checking if the string has been found and if not then add to list
                if(found == false)
                {
                    foundstr.Add(check);
                }
            }
            foreach(string strings in foundstr)
            {
                Console.WriteLine(strings);
            }
            Console.ReadLine();
