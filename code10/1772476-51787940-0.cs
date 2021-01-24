    public class WoodObjectListItem : System.Windows.Forms.ListViewItem
    {
        public Wood WoodObject { get; }
        public WoodObjectListItem(int rowNumber, Wood woodObject) 
            : base(new string[] { rowNumber.ToString(), woodObject.WoodType, woodObject.Condition, woodObject.IsDry })
        {
            WoodObject = woodObject;
        }
        public void ChangeType()
        {
            WoodObject.WoodType = "Oak Wood";
        }
    }
