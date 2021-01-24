    private Syncfusion.Windows.Forms.Gauge.RadialGauge radialGauge1;
    private System.Windows.Forms.TrackBar trackBar1;
    private Syncfusion.Windows.Forms.Gauge.Needle needle1;
    private void InitializeComponent()
    {
         this.needle1 = new Syncfusion.Windows.Forms.Gauge.Needle();
         this.needle1.Value = 0F;
         this.trackBar1 = new System.Windows.Forms.TrackBar();
         this.radialGauge1 = new Syncfusion.Windows.Forms.Gauge.RadialGauge();
         this.trackBar1.Value = (int) needle1.Value;
         
         this.radialGauge1.EnableCustomNeedles = true;
         this.radialGauge1.NeedleCollection.Add(needle1);
         this.radialGauge1.Size = new System.Drawing.Size(230, 230);
         this.radialGauge1.TabIndex = 0;
         this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
    }
