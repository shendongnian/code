    AxAcroPDFLib.AxAcroPDF pdf = new AxAcroPDFLib.AxAcroPDF();
    pdf.Dock = System.Windows.Forms.DockStyle.Fill;
    pdf.Enabled = true;
    pdf.Location = new System.Drawing.Point(0, 0);
    pdf.Name = "pdfReader";
    pdf.OcxState = ((System.Windows.Forms.AxHost.State)(new System.ComponentModel.ComponentResourceManager(typeof(ViewerWindow)).GetObject("pdfReader.OcxState")));
    pdf.TabIndex = 1;
                
    // Add pdf viewer to current form        
    this.Controls.Add(pdf);
    
    pdf.LoadFile(@"C:\MyPDF.pdf");
    pdf.setView("Fit");
    pdf.Visible = true;
