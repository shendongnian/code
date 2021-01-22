     public static string TimeLine(this HtmlHelper helper, string myString1)
        {
            StringBuilder string2 = new StringBuilder();
            DateTime startDate = new DateTime(2010, 1, 1);
            DateTime endDate = new DateTime(2011, 12, 12);
            string2.Append("<table>");
            for (DateTime date = startDate; date <= endDate; date = date.AddMonths(1))
            {
                
                string2.Append("<p>" + date.AddMonths(1) + "</p>");
              
                //DateTime ddd = new DateTime(year, month);
                string2.Append("<tr>");
                for (date = startDate; date <= endDate; date = date.AddMonths(1).AddDays(1))
                {
                    DayOfWeek dw = date.DayOfWeek;
                    var dateShortHand = "";
                    switch (dw)
                    {
                        case DayOfWeek.Monday:
                            dateShortHand = "M";
                            break;
                        case DayOfWeek.Tuesday:
                            dateShortHand = "T";
                            break;
                        case DayOfWeek.Wednesday:
                            dateShortHand = "W";
                            break;
                        case DayOfWeek.Thursday:
                            dateShortHand = "T";
                            break;
                        case DayOfWeek.Friday:
                            dateShortHand = "F";
                            break;
                        case DayOfWeek.Saturday:
                            dateShortHand = "S";
                            break;
                        case DayOfWeek.Sunday:
                            dateShortHand = "S";
                            break;
                    }
                    string2.Append("<td>" + dateShortHand + "</td>");
                }
                string2.Append("</tr>");
                string2.Append("<tr>");
                //for (int i = 1; i <= ff; date = date.AddDays(1))
                //{
                //    var f = date.Day;
                //    string2.Append("<td>" + f + "</td>");
                //}
                string2.Append("</tr>");
                
            }
            string2.Append("</table>");
            return string2.ToString();
        }
