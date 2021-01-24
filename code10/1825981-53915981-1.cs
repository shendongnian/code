    public class EventGuestEmailer
    {
        private class GuestInfo
        {
            public Guid GuestId;
            public string EmailAddress;
        }
        private List<GuestInfo> _guests;
        private IDataAccess _dataStore;
        private IEmailSender _emailer;
       public EventGuestEmailer(IDataAccess dataStore, IEmailSender emailer)
       {
           _dataStore = dataStore;
           _emailer = emailer;
       }
       public void GetGuestsAtEvent(int eventId)
       {
           if (_guests != null) throw new InvalidOperationException($"Cannot call {nameof(GetGuestsAtEvent)} more than once");
           _guests = new List<GuestInfo>();
           foreach (var result in _dataStore.GetEventAttendees(eventId))
           {
               if (result.IsGuest)
               {
                 _guests.Add(new GuestInfo { GuestId = restult.GuestId, EmailAddress = result.EmailAddress });
               }
           }
       }
       public SendEmailToGuests(ITemplate emailTemplate)
       {
           if (_guests == null) throw new Exception($"{nameof(GetGuestsAtEvent)} must be called before {nameof(SendEmailToGuests)}");
           foreach (var guest in _guests)
           {
               var emailBody = template.Apply(guest.GuestId);
               _emailer.Send(emailBody, guest.EmailAddress);
           }
       }
    }
