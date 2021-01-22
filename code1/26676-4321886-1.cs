    Protected Sub LinqDataSource22_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceUpdateEventArgs) Handles LinqDataSource22.Updating
    
                ' The main entity
                Dim updatedObject As FeedbackDraft = e.NewObject
    
                updatedObject.Modified = DateTime.Now
                updatedObject.ModifiedBy = UserHelper.GetCurrentUserName
    
                ' Example: Modify the updated object
                Dim aList As RadioButtonList = FeedbackFormView.FindControl("MyRadioButtonList")
                If aList IsNot Nothing AndAlso Not String.IsNullOrEmpty(aList.SelectedValue) Then
                    updatedObject.aProperty = aList.SelectedValue
                End If
    
    
                ' Main context - for updating parent entity
                Using ctx As New CustomDataContext()
    
                    ' Example: ... more modification of the main entity
                    updatedObject.Status = "Draft"
    
                    ' Deal with child items
                    ' Secondary context - for checking against existing data in DB and removing items that have been unselected in the form
                    Using ctx2 As New CustomDataContext()
    
                        ' We need to pull the record from the database to get the full constructed object graph
                        ' This method does a linq query to retrieve the FeedbackDraft object by ID
                        Dim originalObject As FeedbackDraft = GetOriginalFeedbackDraft(ctx2, updatedObject.FeedbackId)
    
                        ' ... truncated ...
                        ' Loop through CheckBoxList items and updated our entity graph
                        For Each li As ListItem In cbList.Items
                            ' ... code to work with ListItem truncated ...
    
                            Dim c As New ChildObject()
                            updatedObject.ChildObjects.Add(c)
                            ' Set the child collection to insert - this is using the main context
                            ctx.ChildObjects.InsertOnSubmit(c)
                            ' We can also delete things using the secondary context
                            Dim o as OtherChildObject()
                            o = GetOtherChildObjectById(updatedObject.FeedbackId)
                            ctx2.OtherChildObjects.DeleteOnSubmit(o)
                            ctx2.SubmitChanges()
                            
                        Next
                    End Using
    
                    ' You can do further child object updates here...
    
                    ' Now, attach main object for update
                    ctx.PartnerFeedbackDrafts.Attach(updatedObject, e.OriginalObject)
                    ctx.SubmitChanges()
    
                End Using
    
                e.Cancel = True
    
            End Sub
