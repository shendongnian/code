        var dayExists = daysModel.Where(x => x.day_name == day_name).FirstOrDefault();
            if(dayExists==null)
            {
                   PayRateDaysModel days = new PayRateDaysModel();
                   days.day_name = day_name;
                   days.multiplier = rate_list;
                   daysModel.Add(days);
            }
            else
            {
               //update
               dayExists.day_name = "abc";     
              var firstMultiplier= dayExists.multiplier.FirstOrDefault();
              if( firstMultiplier!=null)
              { 
                  firstMultiplier.rate_multiplier = 1;
              }
        
             }
