            string eventID = "5312";
            string LogSource = "Microsoft-Windows-GroupPolicy/Operational";  
            string sQuery = "*[System/EventID=" + eventID + "]";
            var elQuery = new EventLogQuery(LogSource, PathType.LogName, sQuery);
            var elReader = new System.Diagnostics.Eventing.Reader.EventLogReader(elQuery);
            
            List<EventRecord> eventList = new List<EventRecord>();
            for (EventRecord eventInstance = elReader.ReadEvent();
                null != eventInstance; eventInstance = elReader.ReadEvent())
            {
                //Access event properties here:
                //eventInstance.LogName;
                //eventInstance.ProviderName;
                eventList.Add(eventInstance);
            }
