    data = File.ReadAllBytes(@"C:\temp\abc.pdf");
    PdfiumViewer.PdfDocument doc;
    using (Stream stream = new MemoryStream(data))
    {
        doc = PdfiumViewer.PdfDocument.Load(stream);
        var viewer = new PdfiumViewer.PdfViewer();
        viewer.Document = doc;
        var form = new System.Windows.Forms.Form();
        form.Size = new Size(600, 800);
        viewer.Dock = System.Windows.Forms.DockStyle.Fill;
        form.Controls.Add(viewer);
        form.ShowDialog();
    }
