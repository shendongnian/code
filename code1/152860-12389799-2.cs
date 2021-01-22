        private enum eTiming
        {
            eOnTime = 0,
            eSlightDelay = 5,
            eMinorDelay = 15,
            eDelayed = 30,
            eMajorDelay = 45,
            eSevereDelay = 60
        }
        private static eTiming CheckIfTimeDelayed(TimeSpan tsTime)
        {
            eTiming etiming = eTiming.eOnTime;
            foreach (eTiming eT in Enum.GetValues(typeof(eTiming)))
            {
                if (Convert.ToInt16(eT) <= tsTime.TotalMinutes)
                    etiming = eT;
            }
            return etiming;
        }
