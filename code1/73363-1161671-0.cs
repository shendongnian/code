      Public Sub InsertPartialGuid()            
            Dim objSel As TextSelection = DTE.ActiveDocument.Selection        
            Dim NewGUID As String = String.Format("{0}", (System.Guid.NewGuid().ToString().ToUpper().Split("-")(0)))
            objSel.Insert(NewGUID, vsInsertFlags.vsInsertFlagsContainNewText)
            objSel = Nothing
        End Sub
