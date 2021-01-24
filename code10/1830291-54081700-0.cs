    DateTime lastEventTime = DateTime.MinValue;
    int lastTimeIndex = 0;
    void ProcessReceivedEvent(string event)
    {
        // here, parse the event string to get the DateTime
        DateTime eventTime = GetEventDate(event);
        if (lastEventTime == DateTime.MinValue)
        {
            lastTimeIndex = 0;
        }
        else if (eventTime != lastEventTime)
        {
            // get number of seconds since last event
            var elapsedTime = eventTime - lastEventTime;
            var elapsedSeconds = (int)elapsedTime.TotalSeconds;
            
            // For each of those seconds, set the number of events to 0
            for (int i = 1; i <= elapsedSeconds; ++i)
            {
                lastTimeIndex = (lastTimeIndex + 1) % TenDays; // wrap around if we get past the end
                TenDaysEvents[lastTimeIndex] = 0;
            }
        }
        // Now increment the count for the current time index
        ++TenDaysEvents[lastTimeIndex];
    }
