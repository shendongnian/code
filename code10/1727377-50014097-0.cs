            try
            {
                gridView1.BeginUpdate();
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    var rowhandle = gridView1.GetRowHandle(i);
                    if (((MyClass)gridView1.GetRow(rowhandle)).MyProperty)
                        gridView1.SelectRow(rowhandle);
                }
            }
            finally
            {
                gridView1.EndUpdate();
            }
