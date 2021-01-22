     List<DateTime[]> getListWeeks(int annee)
            {
                List<DateTime[]> weeks = new List<DateTime[]>();
                DateTime beginDate = new DateTime(annee, 1, 1);
                DateTime endDate = new DateTime(annee, 12, 31);
                int nb =(int)beginDate.DayOfWeek;
                DateTime monday = beginDate.AddDays(-nb+1); ;
                DateTime saturday = monday.AddDays(6);
                while (monday < endDate)
                {
                        weeks.Add(new DateTime[] { monday, saturday });
                        monday = monday.AddDays(7);
                        saturday = monday.AddDays(6);
                }
                return weeks;
            }
