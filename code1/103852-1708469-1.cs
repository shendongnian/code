        public static void Main()
        {
            DateTime datStart = DateTime.UtcNow;
            const int timesToLoop = 1000000;
            
            for (int i=0; i < timesToLoop; i++)
            {
                WL("Line Number " + i.ToString());
            }
            
            DateTime datEnd = DateTime.UtcNow;
            TimeSpan tsTimeTaken = datEnd - datStart;
            WL("Time Taken: " + tsTimeTaken.TotalSeconds);
            RL();
        }
        
