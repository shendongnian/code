        public string DecHrsToHHMM(double dHours)
        {
            DateTime dTime = new DateTime().AddHours(dHours);
            return dTime.ToString("H:mm");
        }
