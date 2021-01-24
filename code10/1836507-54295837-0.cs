        public bool CheckDate(List<CustomObj> cObj, DateTime fromdate, DateTime toDate, object timeZone)
        {
            bool result = false;
            DateTime date;
            foreach(CustomObj obj in cObj)
            {
                date = DateTime.MinValue;
                switch (timeZone)
                {
                    case "UTC":
                        date = Convert.ToDateTime(obj.StartDate);
                        break;
                    case "IST":
                        // stuff
                        break;
                }
                if (date >= fromdate && date <= toDate)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
