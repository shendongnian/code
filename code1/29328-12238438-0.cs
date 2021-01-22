    Function ExcelIsBusy()
    ExcelIsBusy = Not Application.Ready
    Dim m
    m = Empty
    Const MENU_ITEM_TYPE = 1
    Const NEW_MENU = 18
    
    Dim oNewMenu
    Set oNewMenu = Application.CommandBars("Worksheet Menu Bar").FindControl(MENU_ITEM_TYPE, NEW_MENU, m, m, True)
    If Not (oNewMenu Is Nothing) Then
        If Not oNewMenu.Enabled Then
            ExcelIsBusy = True
            'throw new Exception("Excel is in Edit Mode")
        End If
    End If
    
    End Function
