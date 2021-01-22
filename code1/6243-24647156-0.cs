         public Picker()
        {
            InitializeComponent();
            this.listBox.DrawMode = DrawMode.OwnerDrawVariable;
            this.listBox.MeasureItem += listBoxMetals_MeasureItem;
            this.listBox.DrawItem += listBoxMetals_DrawItem;
        }
        void listBoxMetals_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Brush myBrush = Brushes.Black;
            var item = listBox.Items[e.Index] as Mapping;
            if (e.Index % 2 == 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.GhostWhite), e.Bounds);
            }
            e.Graphics.DrawString(item.Name,
                e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }
