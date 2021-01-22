    #End Region
    #Region "EVENTS"
    
    
    'Current Is Dirty Event
    Public Event CurrentIsDirty As CurrentIsDirtyEventHandler
    ' Delegate declaration.
    Public Delegate Sub CurrentIsDirtyEventHandler(ByVal sender As Object, ByVal e As EventArgs)
    Protected Overridable Sub OnCurrentIsDirty(ByVal e As EventArgs)
        RaiseEvent CurrentIsDirty(Me, e)
    End Sub
    
     'PropertyChanged Event 
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
        
    Protected Overridable Sub OnPropertyChanged(ByVal info As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
    End Sub 
    
    #End Region
    
    #Region "METHODS"
  	Private Sub _BindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.BindingCompleteEventArgs) Handles Me.BindingComplete
        If e.BindingCompleteContext = BindingCompleteContext.DataSourceUpdate Then
            If e.BindingCompleteState = BindingCompleteState.Success And Not e.Binding.Control.BindingContext.IsReadOnly Then
                'Make sure the data source value is refreshed (fixes problem mousing off control)
                e.Binding.ReadValue()
                'if not focused then not a user edit.
                If Not e.Binding.Control.Focused Then Exit Sub
                'check for the lookup type of combobox that changes position instead of value
                If TryCast(e.Binding.Control, ComboBox) IsNot Nothing Then
                    'if the combo box has the same data member table as the binding source, ignore it
                    If CType(e.Binding.Control, ComboBox).DataSource IsNot Nothing Then
                        If TryCast(CType(e.Binding.Control, ComboBox).DataSource, BindingSource) IsNot Nothing Then
                            If CType(CType(e.Binding.Control, ComboBox).DataSource, BindingSource).DataMember = (Me.DataMember) Then
                                Exit Sub
                            End If
                        End If
                    End If
                End If
                IsCurrentDirty = True 'set the dirty flag because data was changed
            End If
        End If
