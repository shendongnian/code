    private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
    {
      if (!navigatingDateTimePicker) {
        /* First set the navigating flag to true so this method doesn't get called again while updating */
        navigatingDateTimePicker = true;
    
        /* using timespan because that's the only way I know how to round times well */
        TimeSpan tempTS = dateTimePickerStart.Value - dateTimePickerStart.Value.Date;
        TimeSpan roundedTimeSpan;
    
	    TimeSpan TDBug = dateTimePickerStart.Value - prevTimePicker1;
    	if (TDBug.TotalMinutes == 59)
	    {
		    // first: if we are going back and skipping an hour it needs an adjustment
    		roundedTimeSpan = TimeSpan.FromMinutes(5 * Math.Floor((tempTS.TotalMinutes - 60) / 5));
		    dateTimePickerStart.Value = dateTimePickerStart.Value.Date + roundedTimeSpan;
	    }
    	else if (dateTimePickerStart.Value > prevTimePicker1)
	    {
		    // round up to the nearest interval
    	    roundedTimeSpan = TimeSpan.FromMinutes(5 * Math.Ceiling(tempTS.TotalMinutes / 5));
	        dateTimePickerStart.Value = dateTimePickerStart.Value.Date + roundedTimeSpan;
        } else {
	        // round down to the nearest interval from prev
    	    roundedTimeSpan = TimeSpan.FromMinutes(5 * Math.Floor(tempTS.TotalMinutes / 5));
	        dateTimePickerStart.Value = dateTimePickerStart.Value.Date + roundedTimeSpan;
        }
        navigatingDateTimePicker = false;
      }
      prevTimePicker1 = dateTimePickerStart.Value;
    }
