    public void financialYearList()
            {
                List<Dictionary<string, DateTime>> diclist = new List<Dictionary<string, DateTime>>();
    //financial year start from july and end june
                int year = DateTime.Now.Month >= 7 ? DateTime.Now.Year + 1 : DateTime.Now.Year;
     
                for (int i = 7; i <= 12; i++)
                {
                    Dictionary<string, DateTime> dic = new Dictionary<string, DateTime>();        
                    var first = new DateTime(year-1, i,1);
                    var last = first.AddMonths(1).AddDays(-1);
                    dic.Add("first", first);
                    dic.Add("lst", last);
                    diclist.Add(dic);
                }
    
                for (int i = 1; i <= 6; i++)
                {
                    Dictionary<string, DateTime> dic = new Dictionary<string, DateTime>();
                    var first = new DateTime(year, i, 1);
                    var last = first.AddMonths(1).AddDays(-1);
                    dic.Add("first", first);
                    dic.Add("lst", last);
                    diclist.Add(dic);
                }
    
    
            }
