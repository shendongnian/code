        for(int eventIndex = 0; eventIndex < NUM_EVENTS; eventIndex++)
        {
            PropertyInfo eventPropertyInfo = 
                this.GetType().GetProperty("Event" + eventIndex);
            if (eventPropertyInfo.GetValue(this, null) == yourValue)
            {
                 //Do Something here
            }
        }
