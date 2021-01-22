    [Serializable]
    public class MyType
    {
        DateTime _StartDate;
        public string StartDate
        {
            set
            {
                _StartDate = DateTime.Parse(value);
            }
            get
            {
                return _StartDate.ToShortDateString();
            }
        }
    }
