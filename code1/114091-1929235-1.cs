    public List<Hashtable> GetEventEntryByEvent(
                ref string logName, ref string machineName, 
                ref string source)
            {
                try
                {
                    //Create our list
                    List<Hashtable> events = new List<Hashtable>();
    
                    //Connect to the EventLog of the specified machine
                    EventLog log = new EventLog(logName, machineName);
    
                    //Now we want to loop through each entry
                    foreach (EventLogEntry entry in log.Entries)
                    {
                        //If we run across one with the right entry source
                        //  we create a new Hashtable
                        //  then we add the Message,Source, and TimeWritten values
                        //  from that entry
                        if (entry.Source == source)
                        {
                            Hashtable entryInfo = new Hashtable();
    
                            entryInfo.Add("Message", entry.Message);
                            entryInfo.Add("InstanceId", entry.InstanceId);
                            entryInfo.Add("Source", entry.Source);
                            entryInfo.Add("TimeWritten", entry.TimeWritten);
                            // You can also replace TimeWritten with TimeGenerated
                            //Add this new Hashtable to our list
                            events.Add(entryInfo);
    
                            entryInfo = null;
                        }
                    }
                    //Return the results
                    return events;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return null;
                }
            }
