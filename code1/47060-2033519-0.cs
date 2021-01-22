    Function Index(ByVal collectionField As FormCollection) As ActionResult
    
            Dim industryCategoryID As Long = collectionField.Item("ddlIndustry")
            If industryCategoryID = 0 Then
                Me.ViewData("IndustryList") = GlobalController.GetIndustryList
                Return View(_service.ListCompanies())
            Else
                Me.ViewData("IndustryList") = GlobalController.GetIndustryList
                Return View(_service.ListCompanies(industryCategoryID))
            End If
    
    End Function
