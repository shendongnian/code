    public class PrintPreviewControlSilent : PrintPreviewControl
    {
        public PrintPreviewControlSilent()
        {
        }
        public new PrintDocument Document
        {
            get { return base.Document; }
            set
            {
                base.Document = value;
                PreviewPrintController ppc = new PreviewPrintController();
                Document.PrintController = ppc;
                Document.Print();
                FieldInfo fi = typeof(PrintPreviewControl).GetField("pageInfo", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                fi.SetValue(this, ppc.GetPreviewPageInfo());
            }
        }
    }
