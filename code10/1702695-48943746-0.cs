            //your base string value
            string baseString = "Hello World !";
            
            for (int i = 0; i < baseString.Length; i++)
            {
                //check if have empty sumbol by position in string
                if (baseString[i] == ' ')
                {
                    //replace symbol logic
                    System.Text.StringBuilder sb = new System.Text.StringBuilder(baseString);
                    //here you can add logic for random number
                    sb[i] = '1';
                    baseString = sb.ToString();
                }
            }
