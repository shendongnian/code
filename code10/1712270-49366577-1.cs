    [Flags]
    public enum ItemType
    {
        Shop = 1 << 0, // == 1
        Farm = 1 << 1, // == 2
        Weapon = 1 << 2, // == 4
        Process = 1 << 3, // == 8
        Sale = 1 << 4 // == 16
    }
