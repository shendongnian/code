            List<Photos> ordered_photolist = photolist.OrderByDescending(p => p.PhotoLabel).ThenBy(r => r.UserID).ToList();
            List<Photos> temp_photolist = new List<Photos>();
            List<Photos> final_photolist = new List<Photos>();
            int UserID = -1;
            int UserIDCount = 0;
            foreach (Photos p in ordered_photolist)
            {
                if (UserID == -1)
                {
                    UserID = p.UserID;
                    temp_photolist.Add(p);
                    UserIDCount++;
                }
                else
                {
                    if ( UserID == p.UserID )
                    {
                        temp_photolist.Add(p);
                        UserIDCount++;
                    }
                    else
                    {
                        if ( UserIDCount >= 3 )
                        {
                            // add temp_photolist to final list
                            int index = final_photolist.FindIndex(item => item.UserID == UserID);
                            if (index == -1)
                            {
                                // element does not exists, do what you need
                                final_photolist.AddRange(temp_photolist);
                            }
                            temp_photolist.Clear();
                            temp_photolist.Add(p);
                            UserIDCount = 1;
                            UserID = p.UserID;
                        }
                        else
                        {
                            temp_photolist.Clear();
                            UserIDCount = 0;
                            UserID = -1;
                        }
                    }
                }
                
            }
