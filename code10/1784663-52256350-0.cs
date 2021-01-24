    public class Worktime
    {
        int _maxWork;
        int _workHours;
        public Worktime(int maxWork)
        {
            _maxWork = maxWork;
        }
        public int NumberOfWorkHours
        {
            get { return _workHours; }
            set
            {
                if (value > _maxWork)
                    throw new ArgumentOutOfRangeException("Work hours should not exceed " + _maxWork);
                _workHours = value;
            }
        }
    }
