            // Showing master policy in GROUPS
            // -----------------------------------------------------------------------------------
            // set tree mode to show settings in GROUPS
            flxAvailableSettings.Tree.Style = TreeStyleFlags.Simple;
            // show outline tree on column 1.
            flxAvailableSettings.Tree.Column = 0;
            flxAvailableSettings.Cols[0].Visible = true;
            flxAvailableSettings.Cols[0].Width = 15;
            flxAvailableSettings.AllowMerging = AllowMergingEnum.Nodes;
            // subtotal on column 1, outline level 0
            flxAvailableSettings.Subtotal(AggregateEnum.None, 0, 0, 0, "{0}");
            // use owner draw to suppress repeating group names in Non-Node rows
            flxAvailableSettings.DrawMode = DrawModeEnum.OwnerDraw;
            flxAvailableSettings.OwnerDrawCell += new C1.Win.C1FlexGrid.OwnerDrawCellEventHandler(flxAvailableSettings_OwnerDrawCell);
            // done, autosize columns to finish
            flxAvailableSettings.AutoSizeCols();
            // -----------------------------------------------------------------------------------
        private void flxAvailableSettings_OwnerDrawCell(object sender, C1.Win.C1FlexGrid.OwnerDrawCellEventArgs e)
        {
            if (!flxAvailableSettings.Rows[e.Row].IsNode && flxAvailableSettings.Cols[e.Col].Name == "PolicyGroup")
                e.Text = "";
        }
