    public class Level1TreeviewRegion
    {
        public Level1TreeviewRegion(Level1Item level1Item)
        {
            Record_Number = level1Item.Record_Number;
            LEVEL1_ID = level1Item.Level1_Id;
            LEVEL1_NAME_WithoutCodes = !string.IsNullOrEmpty(level1Item.Name) ? level1Item.Name.Trim() : "";
            LEVEL1_NAME_WithCodes = !string.IsNullOrEmpty(level1Item.Name) ? level1Item.Level1_Id + "-" + level1Item.Name.Trim() : "";
            SearchString = !string.IsNullOrEmpty(level1Item.Name) ? level1Item.Level1_Id + level1Item.Name.Trim() : "";
        }
        //...
    }
