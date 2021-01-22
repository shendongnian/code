     virtual public bool IsAllDay
            {
                get { return !Start.HasTime; }
                set
                {
                    // Set whether or not the start date/time
                    // has a time value.
                    if (Start != null)
                        Start.HasTime = !value;
                    if (End != null)
                        End.HasTime = !value;
    
                    if (value && 
                        Start != null &&
                        End != null &&
                        object.Equals(Start.Date, End.Date))
                    {
                        Duration = default(TimeSpan);
                        End = Start.AddDays(1);
                    }
                }
            }
