    public double ScaleDate(DateTime date)
        {
            TimeSpan span = this.StopDate - this.StartDate;
            TimeSpan pos = date - this.StartDate;
            double posDays = double.Parse(pos.Days.ToString());
            double spanDays = double.Parse(span.Days.ToString());
            double x = posDays / spanDays;
            return x;
        }
