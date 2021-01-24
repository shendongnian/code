    public partial class Form2 : CustomForm
    {
        Microsoft.Office.Interop.PowerPoint.Presentation ppPresentation;
        Microsoft.Office.Interop.PowerPoint.SlideShowSettings settings;
        Microsoft.Office.Interop.PowerPoint.Application opApp;
        int StartingSlide = 1;
        public Form2()
        {
            InitializeComponent();
        }
        protected override void OnStart(CustomForm Sender)
        {
            Microsoft.Office.Interop.PowerPoint.Application pptApp = new Microsoft.Office.Interop.PowerPoint.Application();
            Microsoft.Office.Core.MsoTriState ofalse = Microsoft.Office.Core.MsoTriState.msoFalse;
            Microsoft.Office.Core.MsoTriState otrue = Microsoft.Office.Core.MsoTriState.msoTrue;
            pptApp.Visible = otrue;
            pptApp.Activate();
            Microsoft.Office.Interop.PowerPoint.Presentations ps = pptApp.Presentations;
            opApp = new Microsoft.Office.Interop.PowerPoint.Application();
            opApp.SlideShowNextSlide += OpApp_SlideShowNextSlide;
            ppPresentation = ps.Open(@"c:\a.pptx", ofalse, ofalse, otrue);
            settings = ppPresentation.SlideShowSettings;
            settings.RangeType = Microsoft.Office.Interop.PowerPoint.PpSlideShowRangeType.ppShowSlideRange;
            settings.StartingSlide = StartingSlide;
            settings.Run();
        }
        private void OpApp_SlideShowNextSlide(Microsoft.Office.Interop.PowerPoint.SlideShowWindow Wn)
        {
            StartingSlide = Wn.View.CurrentShowPosition;
        }
        protected override void OnStop(CustomForm Sender)
        {
            ppPresentation.Close();
            //opApp.Quit();
            Process.Start("cmd", "/c taskkill /im POWERPNT.EXE");
        }
    }
