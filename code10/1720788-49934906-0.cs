            private void _row_Click(object sender, EventArgs e)
            {
                TableRow tableRow = (TableRow)sender;
                TextView title = (TextView)tableRow.GetChildAt(0);
                TextView value = (TextView)tableRow.GetChildAt(1);
            }
