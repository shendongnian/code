        private void messageInfoDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Is this the correct column? (It's actually a DataGridViewImageColumn)
            if (messageInfoDataGridView.Columns[e.ColumnIndex] == messageSeverityDataGridViewTextBoxColumn)
            {
                // Get the row we're formatting
                DataGridViewRow row = messageInfoDataGridView.Rows[e.RowIndex];
                // Get the enum from the row.
                MessageSeverity severity = ((MessageInfo)row.DataBoundItem).MessageSeverity;
                Bitmap cellValueImage;
                // Map the enumerated type to an image...
                // SeverityImageMap is a Dictionary<MessageSeverity,Bitmap>.
                if (ReferenceTables.SeverityImageMap.ContainsKey(severity))
                    cellValueImage = ReferenceTables.SeverityImageMap[severity];
                else
                    cellValueImage = Resources.NoAction;
                // Set the event args.
                e.Value = cellValueImage;
                e.FormattingApplied = true;
            }
        }
