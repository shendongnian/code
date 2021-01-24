    public partial class Ribbon1 : OfficeRibbon
    {
        object missing = System.Type.Missing;
        static internal RibbonButton btnTest = null;
        static internal Office.IRibbonUI rUI = null;
        public Ribbon1()
        {
            InitializeComponent();
            RibbonDropDownItem ddItem1 = new RibbonDropDownItem();
            ddItem1.Label = "Item added at runtime";
            ddList.Items.Add(ddItem1);
            RibbonDropDownItem ddItem2 = new RibbonDropDownItem();
            ddItem2.Label = "Second item added at runtime";
            ddList.Items.Add(ddItem2);
            ddList.SelectedItemIndex = 1;
        }
