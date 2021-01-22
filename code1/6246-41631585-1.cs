    public MainForm()
    {
        InitializeComponent();
        this.listbox1.DrawItem += new DrawItemEventHandler(this.listbox1_DrawItem);
    }
    private void listbox1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
    {
        e.DrawBackground();
        Brush myBrush = Brushes.Black;
        var item = listbox1.Items[e.Index];
        if(e.Index % 2 == 0)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.Gold), e.Bounds);
        }
            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), 
                e.Font, myBrush,e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }
    }
