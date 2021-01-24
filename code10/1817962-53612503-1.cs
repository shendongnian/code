    namespace YourCompany.EventProvider.Api1
    {
        // just an example with json2sharp, use data annotations if you want
        public class Guest
        {
            public int guest_id { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
        }
        public class Participants
        {
            public List<Guest> guests { get; set; }
        }
        public class RootObject
        {
            public int event_id { get; set; }
            public string event_name { get; set; }
            public string start_date { get; set; }
            public string end_date { get; set; }
            public Participants participants { get; set; }
        }
 
        public class Api1EventProvider : IEventProvider
        {
            public Event[] GetEvents()
            {
               RootObject[] api1Response = GetFromApi();
               return _mapper.Map<RootObject[], Event[]>(api1Response);
            }
        }       
    }
