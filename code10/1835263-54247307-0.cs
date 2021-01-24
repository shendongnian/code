    public class Town
    {
        //public Town town = new Town();
        public List<Buildings> buildings = new List<Buildings>();
    
        private List<string> buildingNames = new List<string>() {"Town_Hall", "Market", "Residences", "Mortician", "Bank", "Hotel", "Tailor", "Gunsmith", "General_Store", "Sheriff", "Well", "Gate", "Wall"};
    
        public void ResetTown()
        {
            foreach (Buildings building in this)
            {
                int i = 0;
                i++;
                building.Name = buildingNames[i].ToString();
                building.Level = 0;
            }
        }
    
        public IEnumerator<Buildings> GetEnumerator() 
        { 
            return buildings.GetEnumerator(); 
        } 
    }
