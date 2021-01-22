    public static MachineProductCollection
        MachineProductForMachine(MachineProductCollection MachineProductList, int MachineID)
    {
        List<MachineProduct> found =
            MachineProductList.FindAll(c => c.MachineID == MachineID))
    
        return new MachineProductCollection(found);
    }
