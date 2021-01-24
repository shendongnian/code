    // internal is the default access modifier for types, but it's more descriptive to specify it. 
    internal class Spaceship
    {
    
        private List<Equipment> _equipment = new List<Equipment>();
        
        public IEnumerable<Weapon> Weapons {get {return _equipment.OfType<Weapon>();}}
        public IEnumerable<Shield> Shields {get {return _equipment.OfType<Shield>();}}
        public void RemoveEquipment(Equipment item)
        {
            _equipment.Remove(item);
        }
        public void AddEquipment(Equipment item)
        {
            _equipment.Add(item);
        }
    }
