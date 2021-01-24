    void add_newbox()
    {
        var new_chklistbox = new CheckedListBox{
            Dock=DockStyle.Fill,
            Margin=new Padding(0,0,0,3),
            Location=new Point(20,0),
            Size=new Size(238,94),
            HorizontalScrollbar=true,
            CheckOnClick=true
        };
        
        var new_radiobutton = new RadioButton{
            Text="",
            Dock=DockStyle.Fill,
            Location=new Point(3,3),
            Size=new Size(14,90),
            MaximumSize=new Size(0,90)
        };
        //new_radiobutton.Click += (sender, e) => this.focus=new_chklistbox;
        
        var new_rembutton = new Button{
            Text="-",
            Dock=DockStyle.Fill,
            AutoSize=true,
            AutoSizeMode=AutoSizeMode.GrowAndShrink,
            Margin=new Padding(0)
        };
        //new_rembutton.Click += (sender, e) => rem_items();
        
        var new_tbl = new TableLayoutPanel{
            RowCount=2,
            ColumnCount=1,
            Dock=DockStyle.Fill,
            Margin=new Padding(0)
        };
        var new_panel = new Panel
        {
            Dock = DockStyle.Fill,
            AutoSize = true,
            Margin = new Padding(0)
        };
        new_panel.Controls.Add(new_radiobutton);
        new_panel.Controls.Add(new_rembutton);
        new_tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
        new_tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        new_tbl.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        
        new_tbl.Controls.Add(new_panel, 0, 0);
