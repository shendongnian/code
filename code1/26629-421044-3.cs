    var query = from i in myList
                select new
                {
                    i.FieldA,
                    i.FieldB,
                    i.FieldC
                };
    
    myBindingSource.DataSource = query.ToList(); // Thanks Mark Gravell
    
    // wasn't sure what else to pass in here, but null worked.
    myDataGridTableStyle.MappingName = myBindingSource.GetListName(null); 
    
    myDataGrid.TableStyles.Clear(); // Recommended on MSDN in the code examples.
    myDataGrid.TablesStyles.Add(myDataGridTableStyle);
    myDataGrid.DataSource = myBindingSource;
