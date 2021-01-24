        public bool checkIsValidDateTime(string date)
            {
                var formats = new[] { "dd MMMM yyyy", "MMMM dd yyyy", "dd MMMM ,yyyy", "MMMM dd, yyyy", "d MMMM yyyy", "MMMM d yyyy", "d MMMM ,yyyy", "MMMM d, yyyy" };
                DateTime dt;
            
                var replacements = new[]{
                 new{Find="st",Replace=""},
                 new{Find="nd",Replace=""},
                 new{Find="rd",Replace=""},
                 new{Find="th",Replace=""}
                  };
                foreach (var set in replacements)
                {
                    date = date.Replace(set.Find, set.Replace);
                  
                }
                bool isValid = DateTime.TryParseExact(date, formats, null, DateTimeStyles.None, out dt);
                return isValid;
            }
            
            // which return true for following formats
            
                string input = "1st July 2018";
                string input2 = "July 2nd 2018";
                string input3 = "3rd March ,2018";
                string input4 = "January 4th, 2020";
                string input5 = "20th January 2020";
         bool isvalid1 = checkIsValidDateTime(input); // result true
         bool isvalid2 = checkIsValidDateTime(input2); // result true
         bool isvalid3 = checkIsValidDateTime(input3); // result true
         bool isvalid4 = checkIsValidDateTime(input4); // result true
         bool isvalid5 = checkIsValidDateTime(input5); // result true
