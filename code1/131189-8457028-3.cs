        public void GetClosestDate(DateTime referenceDate, List<DateTime> listDates, int maxResults)
        {
            // final ordered date list
            List<DateTime> finalList = new List<DateTime>();
            
            DateTime selectedDate = DateTime.MaxValue;
                  
            // loop number of results
            for (int i = 0; i < maxResults; i++)
            {
                // get next closest date
                int tempDistance = int.MaxValue;
                foreach (DateTime currentDate in listDates)
                {
                    int currenDistance = this.DateDiff(currentDate, referenceDate);
                    if (currenDistance < tempDistance)
                    {
                        tempDistance = currenDistance;
                        selectedDate = currentDate;
                    }
                }
                // build final list
                finalList.Add(selectedDate);
                // remove element from source list
                listDates.Remove(selectedDate);
            }
            // print results
            foreach (DateTime date in finalList)
            {
                Console.WriteLine(date.ToShortDateString());
            }
        }
        private int DateDiff(DateTime Date1, DateTime Date2)
        {
            TimeSpan time = Date1 - Date2;
            return Math.Abs(time.Days);
        }
    }
