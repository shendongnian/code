    class Product{
    List<InventoryControl> InventoryControls;
    GetInventoryControl(InventoryControlType type){
        return InventoryControls.First(x => x.ControlType == type);
    }
