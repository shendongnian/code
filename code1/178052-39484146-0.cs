    Dim MenuBarTable As DAL.Page.MenuBarDataTable 'The Table Adapter
    MenuBarTable = PageObj.GetMenuBar()  'The generated Get function 
    MenuBarTable.ParentIDColumn.AllowDBNull = True 
       
        For Each row As Page.MenuBarRow In MenuBarTable.Rows
            If row.IsParentIDNull() Then 
                row.SetParentIDNull() 
            End If
        Next
