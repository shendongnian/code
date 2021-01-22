                        if(starttime>endtime)
                        {
                            ;
                        }
                        else
                        {
                           switch (periodtype)
                           {
                              case 0: nextRunTime = nextRunTime.AddHours(period); break;
                              case 1: nextRunTime = nextRunTime.AddMinutes(period); break;
                              case 2: nextRunTime = nextRunTime.AddSeconds(period); break;
                           }
                        }
                    
