     public bool updateEvent(clubEvent newEvent)
        {
            tCon.clubEvents.Attach(newEvent);
            tCon.Refresh(RefreshMode.KeepCurrentValues, settings)
            tCon.SubmitChanges();
            return true;
        }
