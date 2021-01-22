    class Employee
    {
        // field
        private List<Sector> sectors;
        // property to get the sectors
        public List<Sector> Sectors { get { return this.sector; }
    }
    
    // sector class
    class Sector
    {
      int Id { get; set; }
      string Name { get; set; }  
    }
