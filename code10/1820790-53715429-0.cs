    public class Class1
      {
    
        static void Main()
        {
    
    
    
          meetingCentre myCenter = new meetingCentre("EBC-MC_C7");
          meetingRoom myRoom = new meetingRoom("EBC-C7-MR:1_1");
          myCenter.rooms.Add(myRoom);
          myRoom.reservations.Add(new reservation("28.10.2016", "10:00", "11:30", 4, "College", false, ""));
          myRoom.reservations.Add(new reservation("28.10.2016", "12:00", "13:30", 4, "College", false, ""));
          myRoom.reservations.Add(new reservation("29.10.2016", "10:00", "11:30", 4, "College", false, ""));
    
          Console.WriteLine(JsonConvert.SerializeObject(myCenter, Formatting.Indented));
    
    
    
    
    
    
          Console.ReadLine();
        }
    
      }
    
    
      public class meetingCentre
        {
    
          public List<meetingRoom> rooms = new List<meetingRoom>();
    
          public string id;
    
          public meetingCentre(string id)
          {
            this.id = id;
          }
        }
    
        public class meetingRoom
        {
          public List<reservation> reservations = new List<reservation>();
          public string id;
    
          public meetingRoom(string id)
          {
            this.id = id;
          }
        }
    
        public class reservation
        {
    
          public reservation(string d, string f, string t, int pc, string cust, bool v, string n)
          {
            date = d;
            from = f;
            to = t;
            expectedPersonsCount = pc;
            customer = cust;
            videoConference = v;
            note = n;
    
          }
          public string date { get; set; }
          public string from { get; set; }
          public string to { get; set; }
          public int expectedPersonsCount { get; set; }
          public string customer { get; set; }
    
          public bool videoConference { get; set; }
          public string note { get; set; }
    
        }
    
    }
