                    Performance wise custom code will be more use full. 
                    List<int> results;
                    int targetNumber = 0;
                    int nearestValue=0;
                    if (results.Any(ab => ab == targetNumber ))
                    {
                        nearestValue= results.FirstOrDefault<int>(i => i == targetNumber );
                    }
                    else
                    {
                        int greaterThanTarget = 0;
                        int lessThanTarget = 0;
                        if (results.Any(ab => ab > targetNumber ))
                        {
                            greaterThanTarget = results.Where<int>(i => i > targetNumber ).Min();
                        }
                        if (results.Any(ab => ab < targetNumber ))
                        {
                            lessThanTarget = results.Where<int>(i => i < targetNumber ).Max();
                        }
                        if (lessThanTarget == 0 )
                        {
                            nearestValue= greaterThanTarget;
                        }
                        else if (greaterThanTarget == 0)
                        {
                            nearestValue= lessThanTarget;
                        }
                        else if (targetNumber - lessThanTarget < greaterThanTarget - targetNumber )
                        {
                            nearestValue= lessThanTarget;
                        }
                        else
                        {
                                nearestValue= greaterThanTarget;
                        }
                    }
