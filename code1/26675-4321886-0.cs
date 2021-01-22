    Protected Sub LinqDataSource22_Updating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceUpdateEventArgs) Handles LinqDataSource22.Updating
    
                ' The main entity
                Dim updatedObject As PartnerFeedbackDraft = e.NewObject
    
                updatedObject.Modified = DateTime.Now
                updatedObject.ModifiedBy = UserHelper.GetCurrentUserName
    
                ' Example: Modify the updated object
                Dim logisticsList As RadioButtonList = FeedbackFormView.FindControl("LogisticsRadioButtonList")
                If logisticsList IsNot Nothing AndAlso Not String.IsNullOrEmpty(logisticsList.SelectedValue) Then
                    updatedObject.Logistics = logisticsList.SelectedValue
                End If
    
    
                ' Main context - for updating parent entity
                Using ctx As New CustomDataContext()
    
                    ' Example: ... more modification of the main entity
                    updatedObject.Status = "Draft"
    
                    ' Deal with child items
                    ' Secondary context - for checking against existing data in DB and removing items that have been unselected in the form
                    Using ctx2 As New CustomDataContext()
    
                        ' We need to pull the record from the database to get the full constructed object graph
                        Dim originalObject As PartnerFeedbackDraft = GetOriginalPartnerFeedback(ctx2, updatedObject.FeedbackId)
    
                        ' Loop through CheckBoxList items and updated our entity graph
                        For Each li As ListItem In cbList.Items
    
                            Dim cId As Int16 = li.Value
    
                            If li.Selected Then
                                Dim found As Boolean = False
                                ' Check if we already have this value
                                ' If so, don't need to do anything
                                For Each c As PartnerFeedbackInfluenceDraft In originalObject.PartnerFeedbackInfluenceDrafts
                                    If c.InfluenceId = li.Value Then
                                        found = True
                                        Exit For
                                    End If
                                Next
    
                                '' Otherwise, we need to add it.
                                If Not found Then
                                    Dim c As New PartnerFeedbackInfluenceDraft()
                                    c.Ref_Influence = (From ch In ctx.Ref_Influences _
                                        Where ch.InfluenceId = cId _
                                        Select ch).Single()
                                    updatedPartnerFeedback.PartnerFeedbackInfluenceDrafts.Add(c)
                                    ctx.PartnerFeedbackInfluenceDrafts.InsertOnSubmit(c)
                                End If
                            Else
                                ' Remove the item if it is unselected in the form, but exists in the DB.
                                For Each c As PartnerFeedbackInfluenceDraft In originalObject.PartnerFeedbackInfluenceDrafts
                                    If c.InfluenceId = li.Value Then
                                        ctx2.PartnerFeedbackInfluenceDrafts.DeleteOnSubmit(c)
                                        Exit For
                                    End If
                                Next
                                ctx2.SubmitChanges()
                            End If
                        Next
                    End Using
    
                    ' You can do further child object updates here...
    
                    ' Attach main object for update
                    ctx.PartnerFeedbackDrafts.Attach(updatedObject, e.OriginalObject)
                    ctx.SubmitChanges()
    
                End Using
    
                e.Cancel = True
    
            End Sub
