    Public runMSpecOnComplete As Boolean = False
    
    Sub PublishAndRunExternalCommand()
    
        DTE.Windows.Item(Constants.vsWindowKindSolutionExplorer).Activate()
        DTE.ActiveWindow.Object.GetItem("04 - Products\04 - Products.WSS").Select(vsUISelectionType.vsUISelectionTypeSelect)
        DTE.ExecuteCommand("ClassViewContextMenus.ClassViewProject.Publish")
    
        runExternalCommandOnComplete = True
    
    End Sub
