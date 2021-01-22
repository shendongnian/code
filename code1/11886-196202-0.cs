    // 
    // imageListButtons
    // 
    this.imageListButtons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListButtons.ImageStream")));
    this.imageListButtons.TransparentColor = System.Drawing.Color.Transparent;
    this.imageListButtons.Images.SetKeyName(0, "close_normal");
    this.imageListButtons.Images.SetKeyName(1, "close_hover");
    // 
    // lblClose
    // 
    this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
    this.lblClose.BackColor = System.Drawing.Color.Transparent;
    this.lblClose.ImageKey = "close_normal";
    this.lblClose.ImageList = this.imageListButtons;
    this.lblClose.Location = new System.Drawing.Point(381, 7);
    this.lblClose.Margin = new System.Windows.Forms.Padding(0);
    this.lblClose.Name = "lblClose";
    this.lblClose.Size = new System.Drawing.Size(12, 12);
    this.lblClose.TabIndex = 0;
    this.lblClose.MouseLeave += new System.EventHandler(this.lblClose_MouseLeave);
    this.lblClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblClose_MouseClick);
    this.lblClose.MouseEnter += new System.EventHandler(this.lblClose_MouseEnter);
    
    
    private void lblClose_MouseEnter(object sender, EventArgs e)
    {
        lblClose.ImageKey = "close_hover";
    }
    
    private void lblClose_MouseLeave(object sender, EventArgs e)
    {
        lblClose.ImageKey = "close_normal";
    }
    
    private void lblClose_MouseClick(object sender, MouseEventArgs e)
    {
        this.Close();
    }
