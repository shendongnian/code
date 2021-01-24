     eventRecordList = null;
                remoteEventRecordList = Xmlcollection.Cast<Control.Common.Enums.EventViewerDetails>().ToList();
                var distinctLevels = (from row in remoteEventRecordList.AsEnumerable()
                                      let value = row.Level
                                      select value).Distinct();
                foreach (var remoteItem in distinctLevels)
                {
                    if (!AvailbleFilterOptionsObservableCollection.Any(i => i.Name == GetLevelName(Convert.ToByte(remoteItem))))
                    {
                        AvailbleFilterOptionsObservableCollection.Add(new FilteredData
                        {
                            Name = GetLevelName(Convert.ToByte(remoteItem)),
                            Level = Convert.ToByte(remoteItem),
                            IsSelected = true
                        });
                    }
                }
