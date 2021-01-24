        public List<object[]> GetProdVal()
        {
            List<object[]> value = new List<object[]>();
            foreach (var item in valuelist)
            {
                DateTimeConvertor dtc = new DateTimeConvertor();
                double.TryParse(dtc.Year(item.Date.ToString()), out double year);
                double.TryParse(dtc.Month(item.Date.ToString()), out double month);
                double.TryParse(dtc.Day(item.Date.ToString()), out double day);
                object[] val = {
                year,
                month,
                day,                
                item.TotalCost
                };
                value.Add(val);
            }
            return value;
        }
