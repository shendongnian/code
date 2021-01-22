    public static DataGrid AddDataGrid(DataGrid DG, object This, System.Data.DataTable DS)
    {
    
    
    	try {
    		DG.DataSource = DS;
    		This.Controls.Add(DG);
    		DataGridTableStyle TblS = new DataGridTableStyle { MappingName = DS.TableName };
    		DG.TableStyles.Clear();
    		DG.TableStyles.Add(TblS);
    
    
    		for (ColIndex = 0; ColIndex <= DS.Columns.Count - 1; ColIndex++) {
    			int maxlength = 0;
    			Graphics g = DG.CreateGraphics();
    
    			// Take width of one blank space and add to the new width of the Column.
    			int offset = Convert.ToInt32(Math.Ceiling(g.MeasureString(" ", DG.Font).Width));
    
    			int i = 0;
    			int intaux = 0;
    			string straux = null;
    			int tot = DS.Rows.Count;
    
    			for (i = 0; i <= (tot - 1); i++) {
    				straux = DS.Rows[i][ColIndex].ToString();
    				// Get the width of Current Field String according to the Font.
    				intaux = Convert.ToInt32(Math.Ceiling(g.MeasureString(straux, DG.Font).Width));
    				if ((intaux > maxlength)) {
    					maxlength = intaux;
    				}
    			}
    
    			// Assign New Width to DataGrid column.
    			DG.TableStyles(DS.TableName).GridColumnStyles(ColIndex).Width = maxlength + offset;
    
    		}
    
    
    	} catch (Exception ex) {
    		Debug.WriteLine(ex.Message);
    	} finally {
    		DG.Show();
    	}
    
    	return DG;
    }
    
    
    
    private void AddDataGrid(DataSet Ds)
    {
    	AddDataGrid(new DataGrid { Dock = DockStyle.Fill }, this, Ds.Tables[0]);
    
    }
