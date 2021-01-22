    public partial class ThisAddIn
    {
        internal static Application Context { get; private set; }
    
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Context = Application;
        }
        ...
    }
    
    public partial class MyRibbon : OfficeRibbon
    {
        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            DoStuffWithApplication(ThisAddIn.Context);
        }
        ...
    }
