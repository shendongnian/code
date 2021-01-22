Option Explicit
Public Function IsDataCellBoldOrItalic() As Boolean
    Dim rngName As Name
    Dim intersectRange As Name
    
    For Each rngName In ActiveWorkbook.Names
        If Not Intersect(rngName.RefersToRange, Application.ThisCell) Is Nothing Then
            IsDataCellBoldOrItalic = False
            Exit Function
        End If
    Next
    
    'Now we know we are not in a "header" cell
    IsDataCellBoldOrItalic = Application.ThisCell.Font.Bold Or Application.ThisCell.Font.Italic
End Function
