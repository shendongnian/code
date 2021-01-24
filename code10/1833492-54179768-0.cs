    internal void AddControl(Models.CdConfig selectedCd)
        {
            SelectedCds.Add(selectedCd);
            if (selectedCd.DataType == CdType.Combo || selectedCd.DataType == CdType.Choice)
            {
                subItemHeight = 23;
            }
            else
            {
                subItemHeight = 30;
            }
            int currItemRowCount = getItemRowCount(selectedCd);
            Panel controlPanel = new Panel() // the panel that is visible
            {
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                Location = new Point(3,3),
                Size = new Size(this.Size.Width - margin * 2 * 2 - scrollbarbuff, itemHeight + subItemHeight * currItemRowCount)
            };
            TableLayoutPanel t1 = new TableLayoutPanel() // main tlp
            {
                ColumnCount = 1,
                RowCount = 2,
                Size = new Size(this.Size.Width - margin * 2 * 2 - scrollbarbuff, itemHeight + subItemHeight * currItemRowCount)
            };
            t1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            t1.RowStyles.Add(new RowStyle(SizeType.Absolute, itemHeight));
            t1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            TableLayoutPanel tHeader = new TableLayoutPanel() // label and delete button
            {
                ColumnCount = 2,
                RowCount = 1,
                Size = new Size(this.Size.Width - margin * 2 * 2 - scrollbarbuff, itemHeight)
            };
            tHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            t1.Controls.Add(tHeader, 0, 0);
            // Add the label
            Label lbl = new Label()
            {
                Text = selectedCd.DisplayName,
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
                Margin = new Padding(0, 3 * 2, 0, 0)
            };
            tHeader.Controls.Add(lbl, 0, 0);
            Button deleteBtn = new Button()
            {
                Text = "Delete",
                Anchor = AnchorStyles.Right | AnchorStyles.Top,
                Margin = new Padding(0, 2, 3 * 2, 0)
            };
            deleteBtn.Tag = controlPanel;
            deleteBtn.Click += HandleDelete;
            tHeader.Controls.Add(deleteBtn, 1, 0);
            controlPanel.Controls.Add(t1);
            // For the control
            TableLayoutPanel tControl = CreateCdControl(selectedCd, currItemRowCount);
            
            t1.Controls.Add(tControl, 0, 1);
            
            this.Controls.Add(controlPanel);
            controlPanel.Tag = selectedCd; // for convenience
        }
