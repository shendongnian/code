            var text = "31235";
            
            //returns true or false if the number can be parsed / converted
            var isValidNumber = Int32.TryParse(text, out int result);
            if (isValidNumber)
            {
                Convert.ToInt32(text);
            }
            else
            {
                //error handling here
            }
