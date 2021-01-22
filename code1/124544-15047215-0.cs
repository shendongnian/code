    public DateTime? EndDate
        {
            get
            {
                DateTime? returnValue = null;
                if (endDateDateTimePicker.Checked) 
                { 
                    returnValue = endDateDateTimePicker.Value; 
                }
                return returnValue;
            }
            set
            {
                if (value.HasValue)
                {
                    endDateDateTimePicker.Checked = true;
                    endDateDateTimePicker.Value = value.Value;
                }
                else
                {
                    endDateDateTimePicker.Checked = false;
                }
            }
        }
