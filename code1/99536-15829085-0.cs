    public int RemoveNonWorkingDays(int numberOfDays){
				
				int workingDays = 0;
				
				int firstWeek =	7 - (int)_now.DayOfWeek;
				
				if(firstWeek < 7){
					
					if(firstWeek > numberOfDays)
						return numberOfDays;
					
					workingDays += firstWeek-1;
					numberOfDays -= firstWeek;
				}
				
				
				int lastWeek = numberOfDays % 7;
				
				if(lastWeek > 0){
					numberOfDays -= lastWeek;
					workingDays += lastWeek - 1;
				
				}
				
				workingDays += (numberOfDays/7)*5;
				
				return workingDays;
			}
