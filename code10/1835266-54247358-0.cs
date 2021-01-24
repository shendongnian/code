    public class Town
    {
        private List<Building> buildings;
        private List<string> buildingNames = new List<string>() {"Town_Hall", "Market", "Residences", "Mortician", "Bank", "Hotel", "Tailor", "Gunsmith", "General_Store", "Sheriff", "Well", "Gate", "Wall"};
        public Town(List<Building> buildings)
        {
           this.buildings = buildings;
        }
    
        public void ResetTown()
        {
            foreach (Building building in buildings)
            {
                building.Name = buildingNames[i].ToString();
                building.Level = 0;
            }
        }
    
        public IEnumerator<Building> GetEnumerator() 
        { 
            return buildings.GetEnumerator(); 
        } 
    }
    
    public class Building
    {
        public string Name {get; set;}
        public int Level {get; set;}
    }
