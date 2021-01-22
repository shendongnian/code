        public bool IsTimeString(string ts)
        {
            string[] time = ts.Split(':');
            int h;
            int m;
            if (time.Length == 2)
                return int.TryParse(time[0], out h) &&
                       int.TryParse(time[1], out m) &&
                       h >= 0 && h < 24 &&
                       m >= 0 && m < 60;
            else
                return false;
        }
