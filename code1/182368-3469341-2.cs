    public partial class Job
    {
        #region Primitive Properties
        
        public virtual int Id
        {
            get;
            set;
        }
        
        public virtual int ScheduleId
        {
            get { return _scheduleId; }
            set
            {
                if (_scheduleId != value)
                {
                    if (Schedule != null && Schedule.Id != value)
                    {
                        Schedule = null;
                    }
                    _scheduleId = value;
                }
            }
        }
        private int _scheduleId;
        
        public virtual string Title
        {
            get;
            set;
        }
        
        public virtual string Description
        {
            get;
            set;
        }
    
        #endregion
        #region Navigation Properties
        
        public virtual Schedule Schedule
        {
            get { return _schedule; }
            set
            {
                if (!ReferenceEquals(_schedule, value))
                {
                    var previousValue = _schedule;
                    _schedule = value;
                    FixupSchedule(previousValue);
                }
            }
        }
        private Schedule _schedule;
    
        #endregion
        #region Association Fixup
        
        private void FixupSchedule(Schedule previousValue)
        {
            if (previousValue != null && previousValue.Job.Contains(this))
            {
                previousValue.Job.Remove(this);
            }
        
            if (Schedule != null)
            {
                if (!Schedule.Job.Contains(this))
                {
                    Schedule.Job.Add(this);
                }
                if (ScheduleId != Schedule.Id)
                {
                    ScheduleId = Schedule.Id;
                }
            }
        }
    
        #endregion
    }
    
    public partial class Schedule
    {
        #region Primitive Properties
        
        public virtual int Id
        {
            get;
            set;
        }
        
        public virtual string Description
        {
            get;
            set;
        }
    
        #endregion
        #region Navigation Properties
        
        public virtual ICollection<Job> Job
        {
            get
            {
                if (_job == null)
                {
                    var newCollection = new FixupCollection<Job>();
                    newCollection.CollectionChanged += FixupJob;
                    _job = newCollection;
                }
                return _job;
            }
            set
            {
                if (!ReferenceEquals(_job, value))
                {
                    var previousValue = _job as FixupCollection<Job>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupJob;
                    }
                    _job = value;
                    var newValue = value as FixupCollection<Job>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupJob;
                    }
                }
            }
        }
        private ICollection<Job> _job;
    
        #endregion
        #region Association Fixup
        
        private void FixupJob(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Job item in e.NewItems)
                {
                    item.Schedule = this;
                }
            }
        
            if (e.OldItems != null)
            {
                foreach (Job item in e.OldItems)
                {
                    if (ReferenceEquals(item.Schedule, this))
                    {
                        item.Schedule = null;
                    }
                }
            }
        }
    
        #endregion
    }
