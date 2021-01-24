	private double Oillube()
	{
		//if they are both checked
		if(lubeChbox.Checked && oilChbox.Checked)
		{
			//Creating Variables sum to hold the value of the two
			double sum;
			sum = OIL_CHANGE + LUBE_JOB;
			//returning sum
			return sum;
		}
		
		//checking if the Oil is checked
		if (oilChbox.Checked)
		{
			return OIL_CHANGE;
		}
		//checking if the lube is checked
		if (lubeChbox.Checked)
		{
			return LUBE_JOB;
		}
		//just returning to get ride off the red line under the Method
		return 0;
	}
