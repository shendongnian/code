        public string ActualDuration
        {
            get {
                YourDataContext db = new YourDataContext();
                return
                    db.TaskDurations.Where(t => t.task_id == this.id).
                        Sum (t => t.duration);
            }
        }
