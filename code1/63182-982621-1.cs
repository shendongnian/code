            foreach (DataGridViewRow row in grid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == myValue)
                    {
                        goto EndOfLoop;
                        //Do Something useful
                        //break out of both foreach loops.
                    }
                }
            
            }
            EndOfLoop: ;
