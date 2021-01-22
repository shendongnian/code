      foreach(KeyValuePair<DateTime, ChangedValues> changedValForDate in _changedValForDates)
        {
                        foreach (KeyValuePair<string, int> TypVal in changedValForDate.Value.TypeVales)
                        {
                            RefreshProgress("Daten werden geändert...", count++, false);
        
                            if (IsProgressCanceled)
                            {
                                break; //I miss goto :|
                            }
                        }
                  
                     if (IsProgressCanceled)
                     {
                                break; //I really miss goto now :|
                     }//waaaAA !! so many brakets, I hate'm
        }
