        static void Main(string[] args)
        {
            String timeText = "3/23/2015 12:00:13 AM"; 
            String timeText2 = "3/23/2015 1:45:03 AM"; 
            DateTime time = Convert.ToDateTime(timeText);
            string temp = time.ToString("HH:mm:ss");
            DateTime time2 = Convert.ToDateTime(timeText2);
            string temp2 = time2.ToString("HH:mm:ss");
            TimeSpan t1 = TimeSpan.Parse(temp);
            TimeSpan t2 = TimeSpan.Parse(temp2);
            Console.Out.WriteLine(t1 + t2);  // 01:45:16
            Console.ReadLine();
        }
