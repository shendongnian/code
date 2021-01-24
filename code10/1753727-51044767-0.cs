        void add_newbox()
        {
            var new_chklistbox = new CheckedListBox
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, 3),
                Location = new Point(20, 0),
                Size = new Size(238, 94),
                HorizontalScrollbar = true,
                CheckOnClick = true
            };
            var new_radiobutton = new RadioButton
            {
                Text = "",
                Dock = DockStyle.Fill,
                Location = new Point(3, 3),
                Size = new Size(14, 90),
                MaximumSize = new Size(0, 90)
            };
            new_radiobutton.Click += (sender, e) => this.focus = new_chklistbox;
            var new_rembutton = new Button
            {
                Text = "-",
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(0)
            };
            new_rembutton.Click += (sender, e) => rem_items();
            //var new_tbl = new TableLayoutPanel
            //{
            //    RowCount = 2,
            //    ColumnCount = 1,
            //    Dock = DockStyle.Fill,
            //    Margin = new Padding(0)
            //};
            //new_tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            //new_tbl.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            //new_tbl.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            //new_tbl.Controls.Add(new_radiobutton, 0, 0);
            //new_tbl.Controls.Add(new_rembutton, 0, 1);
            tbl_groups.RowCount = tbl_groups.RowCount + 1;
            tbl_groups.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tbl_groups.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tbl_groups.Controls.Add(new_radiobutton, 0, tbl_groups.RowCount - 1);
            tbl_groups.Controls.Add(new_rembutton, 1, tbl_groups.RowCount - 1);
        }
