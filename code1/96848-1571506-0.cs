                // ---- Create a new list
                List<string> appointmentTimes = new List<string>();
                // ---- If information is pulled back
                if (myResults != null)
                {
                    TimeSpan time = TimeSpan.FromMinutes(30);
                    DateTime FirstTime = Convert.ToDateTime(myResult.firstStart);
                    DateTime LatestTime = Convert.ToDateTime(myResult.lastEnd);
                    
                    while (FirstTime < LatestTime )
                    {
                        appTimes.Add(FirstTime .ToString());
                        FirstTime += time;
                    }
                }
