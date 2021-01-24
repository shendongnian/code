     Sub DisplayViewDef() 
       'Displays the XML definition of a View object 
       Dim objName As Outlook.NameSpace 
       Dim objViews As Outlook.Views 
       Dim objView As Outlook.View 
   
       Set objName = Application.GetNamespace("MAPI") 
       Set objViews = objName.GetDefaultFolder(olFolderInbox).Views 
       'Return a view called Table View if it already exists, else create one 
       Set objView = objViews.Item("Table View") 
       If objView Is Nothing Then 
         Set objView = objViews.Add("Table View", olTableView, olViewSaveOptionAllFoldersOfType) 
       End If 
       MsgBox objView.XML 
     End Sub
