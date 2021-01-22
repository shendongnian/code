     foreach (KeyValuePair<DateTime, ChangedValues> changedValForDate in _changedValForDates)
                {
                    foreach (KeyValuePair<string, int> TypVal in changedValForDate.Value.TypeVales)
                    {
                        RefreshProgress("Daten werden geändert...", count++, false);
    
                        if (IsProgressCanceled)
                        {
                            goto TheEnd; //I like goto :)
                        }
                    }
                }
    TheEnd:
    
