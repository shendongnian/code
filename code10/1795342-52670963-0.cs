    public class Date
    {
        private int Month;
        private int Day;
        private int Year;
        public Date()
        {
            SetDefaultDate();
        }
        public Date(int M, int D, int Y)
        {
            SetDate(M, D, Y);
        }
        public void SetDate(int M, int D, int Y)
        {
            if (IsValidDate(M, D, Y))
            {
                Month = M;
                Day = D;
                Year = Y;
            }
            else
            {
                SetDefaultDate();
            }
        }
        private bool IsValidDate(int M, int D, int Y)
        {
            // validation logic.. return true if all parameters result in valid date
            // false if they do not.  If it is an invalid date print the failure message.
            return true;
        }
        private void SetDefaultDate()
        {
            Month = 1;
            Day = 1;
            Year = 1900;
        }
    }
