    public partial class ThisAddIn
    {//this is the event of the startup of the powerpoint
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {//this is the event that will trigger when you select anything in you presentation 
            this.Application.WindowSelectionChange += new Microsoft.Office.Interop.PowerPoint.EApplication_WindowSelectionChangeEventHandler(Application_WindowSelectionChange);
        }
        void Application_WindowSelectionChange(Microsoft.Office.Interop.PowerPoint.Selection Sel)
        {
            //here you will delete the selected item
            Sel.Delete();
        }
