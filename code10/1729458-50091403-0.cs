    public class Slot
    {
        public GameObject Icon;
    
        public void PlaceIconToSlot()
        {
            // If you overwrite it, the garbage collector will destroy it a some point anyways,
            // but it doesn't hurt to do this destroy call
            Destroy(Icon);    
            Icon = Instantiate(...);
        }
    }
