     public string DurationString
            {
                get 
                {
                    if (this.Duration.TotalHours < 24)
                        return new DateTime(this.Duration.Ticks).ToString("HH:mm");
                    else //If duration is more than 24 hours
                    {
                        double totalminutes = this.Duration.TotalMinutes;
                        double hours = totalminutes / 60;
                        double minutes = this.Duration.TotalMinutes - (Math.Floor(hours) * 60);
                        string result = string.Format("{0}:{1}", Math.Floor(hours).ToString("00"), Math.Floor(minutes).ToString("00"));
                        return result;
                    }
                } 
            }
