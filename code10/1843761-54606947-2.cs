    public class SubjectAccessor
    {
        private readonly Schedule _schedule;
        public SubjectAccessor(Schedule schedule)
        {
            _schedule = schedule;
        }
        public string this[int index]
        {
            get {
                switch (index) {
                    case 1: return _schedule.Subject1;
                    case 2: return _schedule.Subject2;
                    case 3: return _schedule.Subject3;
                    default: return null;
                }
            }
            set {
                switch (index) {
                    case 1: _schedule.Subject1 = value; break;
                    case 2: _schedule.Subject2 = value; break;
                    case 3: _schedule.Subject3 = value; break;
                    default: break;
                }
            }
        }
    }
    public SubjectAccessor Subject { get; }
    public Schedule()
    {
        Subject = new SubjectAccessor(this);
    }
