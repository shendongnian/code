            var stringDates = new List<string> {"01/09/10", "31/08/10", "01/01/10"};
            
            var dates = stringDates.ConvertAll(DateTime.Parse);
            dates.Sort();
            var lastDateInSequence = new DateTime();
            var firstDateInSequence = new DateTime();  
            foreach (var range in dates.GroupBy(d => { var x = lastDateInSequence;  
                                                       lastDateInSequence = d;
                                                       if ((d - x).TotalDays != 1)   
                                                           firstDateInSequence = d;
                                                       return firstDateInSequence;  
            }))
            {
                var sb = new StringBuilder();
                sb.Append(range.First().ToShortDateString());
                sb.Append(" => ");
                sb.Append(range.Last().ToShortDateString());
                Console.WriteLine(sb.ToString());
            }
