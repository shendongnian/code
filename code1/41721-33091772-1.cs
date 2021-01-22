    public partial class DateTimePickerWithReadOnly : DateTimePicker
    {
      Bitmap ReadOnlyImage;
      // We maintain a "shadow" control to avoid capturing selections in the snapshot.
      // If you use different formatting or styles just make sure the shadow is set to match!
      DateTimePicker Shadow = new DateTimePicker(); 
      public DateTimePickerWithReadOnly()
      {
        InitializeComponent(); 
        CaptureBitmap();
        this.ValueChanged += new EventHandler(DateTimePickerWithReadOnly_ValueChanged);
      }
      private void CaptureBitmap()
      {
        Shadow.Value = Value;
        Shadow.Size = Size;
        ReadOnlyImage = new Bitmap(Width, Height);
        Shadow.DrawToBitmap(ReadOnlyImage, new Rectangle(0, 0, Size.Width, Size.Height));
      }
      void DateTimePickerWithReadOnly_ValueChanged(object sender, EventArgs e)
      {
        CaptureBitmap();
      }
      protected override void DefWndProc(ref Message m)
      {
        base.DefWndProc(ref m);
        // WM_PAINT is 0x000F
        if ((m.Msg == 0x000F) && !Enabled)
        {
          Graphics g = base.CreateGraphics();
          g.DrawImage(ReadOnlyImage, new Rectangle(0, 0, Size.Width, Size.Height));
          g.Dispose();
        }
      }
    }
