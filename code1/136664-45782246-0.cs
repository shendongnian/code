    public class Hero
    {
    
        [Inject]
        private IInventory Inventory { get; set; }
    
        [Inject]
        private IArmour Armour { get; set; }
    
        [Inject]
        protected IWeapon Weapon { get; set; }
    
        [Inject]
        private IAction Jump { get; set; }
    
        [Inject]
        private IInstanceProvider InstanceProvider { get; set; }
    
    
    }
