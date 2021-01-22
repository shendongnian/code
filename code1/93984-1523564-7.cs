    class Room 
    {
       private string sectionOne;
       private string sectionTwo;
       
       public string SectionOne 
       {
          get 
          {
            return sectionOne; 
          }
          set 
          { 
            sectionOne = Check(value); 
          }
       }
    }
    
    Room r = new Room();
    r.SectionOne = "enter";
