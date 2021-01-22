        private DateTime ParseDateTime(object data)
        {
		    if (data is DateTime)
			{
			    // already a date-time.
				return (DateTime)data;
			}
			else if (data is string)
			{
				// it's a local-format string.
				string dateString = (string)data;
				DateTime parseResult;
				if (DateTime.TryParse(dateString, CultureInfo.CurrentCulture,
                                      DateTimeStyles.AssumeLocal, out parseResult))
				{
					return parseResult;
				}
				else
				{
					throw new ArgumentOutOfRangeException("data", 
                                       "could not parse this datetime:" + data);
				}
			}
			else
			{
				// it's neither a DateTime or a string; that's a problem.
				throw new ArgumentOutOfRangeException("data", 
                                      "could not understand data of this type");
			}
		}
		
