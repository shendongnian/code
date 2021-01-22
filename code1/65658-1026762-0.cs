        static void Main(string[] args)
        {
            Console.WriteLine(Add("4:20am","0:30pm").ToString());
            Console.WriteLine(Add("15:00pm", "1:00am").ToString());
            Console.WriteLine(Add("5:00am", "12:00pm").ToString());
        }
        static TimeSpan Add(string time1, string time2)
        {
            bool time1IsAfternoon = time1.Contains("pm");
            bool time2IsAfternoon = time2.Contains("pm");
            time1 = time1.Replace("pm", "").Replace("am", "").Trim();
            time2 = time2.Replace("pm", "").Replace("am", "").Trim();
            int time1Hours = int.Parse(time1.Split(':')[0]);
            int time1Minutes = int.Parse(time1.Split(':')[1]);
            int time2Hours = int.Parse(time2.Split(':')[0]);
            int time2Minutes = int.Parse(time2.Split(':')[1]);
            TimeSpan timeSpan1 = GetTimeSpan(time1Hours, time1Minutes, time1IsAfternoon);
            TimeSpan timeSpan2 = GetTimeSpan(time2Hours, time2Minutes, time2IsAfternoon);
            return timeSpan1.Add(timeSpan2);
        }
        static TimeSpan GetTimeSpan(int hours, int minutes, bool isAfternoon)
        {
            if (isAfternoon)
            {
                if (hours < 12)
                {
                    hours += 12;
                }
            }
            return new TimeSpan(hours, minutes, 00);
        }
