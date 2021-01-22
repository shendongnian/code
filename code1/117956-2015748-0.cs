    foreach (TableRow row in table.Rows)
        {
            var checkBox = (CheckBox)row.Cells[0].Controls[0]; //Assuming the first control of the first cell is always a CheckBox.
            if (checkBox.Checked)
            {
                var col2 = (TextBox)row.Cells[1].Controls[0];
                /* Do Stuff With col2 */
            }
            else
            {
                /* Do Stuff */
            }
        }
