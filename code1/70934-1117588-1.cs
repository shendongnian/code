    public static MachineProductCollection
        MachineProductForMachine(MachineProductCollection MachineProductList, int MachineID)
    {
        IEnumerable<MachineProduct> found =
            MachineProductList.Where(c => c.MachineID == MachineID))
    
        return new MachineProductCollection(found);
    }
