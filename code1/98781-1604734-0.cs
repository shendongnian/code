     class MyCustomlistView : ListView
        {
            public MyCustomlistView()
                : base()
            {
                SetStyle(ControlStyles.UserPaint, true);
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                e.Graphics.DrawString("This is a custom string", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.Black, new PointF(0, 50));
            }
    
        }
