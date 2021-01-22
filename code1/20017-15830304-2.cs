    private void MakeGridViewPrinterFriendly(GridView gridView) {  
        if (gridView.Rows.Count > 0) {          
            gridView.UseAccessibleHeader = true;  
            gridView.HeaderRow.TableSection = TableRowSection.TableHeader;  
        }  
    } 
 
