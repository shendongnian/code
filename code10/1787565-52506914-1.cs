     private class DateTimeInp
        {
            public string dateInp { get; set; }
            public string timeInp { get; set; }
    
            public DateTime? ToDateTime()
            {
                string fullDateTime = dateInp + " " + timeInp;
                DateTime toDateTime;
                if(DateTime.TryParse(fullDateTime, out toDateTime))
                {
                    return toDateTime;
                }
                return null;
            }
        }
