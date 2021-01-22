    public class PhoneDisplay
    {
        long phoneNum;
        public PhoneDisplay(long number)
        {
            phoneNum = number;
        }
        public override string ToString()
        {
            return string.Format("{0:###-###-####}", phoneNum);
        }
    }
