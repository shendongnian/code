    class MyDevice : PdfDevice
    {
        public MyDevice(PdfRenderingOptions options, string file) 
            : base(options, file)
        {
        }
        public override void BeginPage(SizeF size)
        {
            //This method is called at the beginning of new page.
            base.BeginPage(size);
        }
    }
