    private void Form1_Load(object sender, EventArgs e)
    {
        QuickPDFAX0718.PDFLibrary pdf = new QuickPDFAX0718.PDFLibrary();
    
        qp.UnlockKey("......Licence Key......");
    
        // Open PDF File
        int Handle = qp.DAOpenFile("C:\\sample.pdf", null);
    
        // Get Total Number of Pages in a PDF File
        int PageCount = qp.DAGetPageCount(Handle);
    
        int PageNo = 1;
    
        // It will get Reference of page 1 from PDF file
        int PageRefNo = qp.DAFindPage(Handle, PageNo);
    
        // You can change this parameter for Zoom In/Zoom Out purpose
        int Zoom = 76;
        double pageWidth = qp.DAGetPageWidth(Handle, PageRefNo) / Zoom;
        double pageHeight = qp.DAGetPageHeight(Handle, PageRefNo) / Zoom;
    
        // DPI use for rendering the page. Increase DPI will increate quality of image
        int dpi = 92;
    
        // Calculate Dimension of final output image
        Bitmap b = new Bitmap(Convert.ToInt32(pageWidth * dpi), Convert.ToInt32(pageHeight * dpi));
    
        // This will Draw render image on GDI
        using (Graphics g = Graphics.FromImage(b))
        {
    	IntPtr dc = g.GetHdc();
    	qp.DARenderPageToDC(Handle, PageRefNo, dpi, (int)dc);
    	g.ReleaseHdc(dc);
        }
    
        // Assigne rendered image to PictureBox Control which will display PDF on Windows Form.
        pictureBox1.Image = b;
        pictureBox1.BorderStyle = BorderStyle.Fixed3D;
    }
