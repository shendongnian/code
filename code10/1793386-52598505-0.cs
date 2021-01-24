        public static string CheckDuplicate(string text)
        {
            var textArray = text.Split('-');    
            int[] textArrayNum = textArray.Select(s => int.Parse(s)).ToArray();
            if (textArrayNum.Length != textArrayNum.Distinct().Count()) 
            {
                string result = "Duplicate";  // most inner scope, hides the static field
            }
            else
            {
                // same level as before and thus completely unrelated to that one, also hides the static field
                string result = "No Duplicate";
            }
            return result;  // references the static field
        }
