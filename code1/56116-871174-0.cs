    DataSet ds = new DataSet();
              da.Fill(ds);
              int width = ds.Tables[0].Columns.Count;
              int height = ds.Tables[0].Rows.Count;
              object[,] retList = new object[height, width];
              for (int i = 0; i < height; i++)
              {
                DataRow r = ds.Tables[0].Rows[i];
                for (int j = 0; j < width; j++)
                  retList[i, j] = r.ItemArray[j];
              }
              Excel.Range range = mWs.get_Range(destination, mWs.Cells[destination.Row + height - 1, destination.Column + width - 1]);
              range.set_Value(Missing.Value, retList);
              System.Runtime.InteropServices.Marshal.ReleaseComObject(range);
              range = null;
