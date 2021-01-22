           private void AllMeetings()
        {
            Customer_ServiceClient service = new Customer_ServiceClient();
            _MeetCollection.Clear();
            foreach (MeetList meet in service.ReadMeetList())
            { 
                _MeetCollection.Add(new Meets
                {
                    Date = meet.MeetDate,
                    Time = meet.MeetTime,
                    Description = meet.MeetDescr
                });                               
            }            
        }
  
