    class Spaceship
    {
    
        private List<Equipment> _equipment = new List<Equipment>();
        
        IEnumerable<Weapon> Weapons {get {return _equipment.OfType<Weapon>();}}
        IEnumerable<Shield> Shields {get {return _equipment.OfType<Shield>();}}
        public void RemoveEquipment(Equipment item)
        {
            _equipment.Remove(item);
        }
        public void AddEquipment(Equipment item)
        {
            _equipment.Add(item);
        }
    }
