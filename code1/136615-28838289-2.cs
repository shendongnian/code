    Private Sub _DataSourceChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.DataSourceChanged
        _parentBindingSource = Nothing
        If Me.DataSource Is Nothing Then
            _dataSet = Nothing
        Else
            'get a reference to the dataset
            Dim bsTest As BindingSource = Me
            Dim dsType As Type = bsTest.DataSource.GetType
            'try to cast the data source as a binding source
            Do While Not TryCast(bsTest.DataSource, BindingSource) Is Nothing
                'set the parent binding source reference
                If _parentBindingSource Is Nothing Then _parentBindingSource = bsTest
                'if cast was successful, walk up the chain until dataset is reached
                bsTest = CType(bsTest.DataSource, BindingSource)
            Loop
            'since it is no longer a binding source, it must be a dataset or something else
            If TryCast(bsTest.DataSource, DataSet) Is Nothing Then
                'Cast as dataset did not work
                
                If dsType.IsClass = False Then
                    Throw New ApplicationException("Invalid Binding Source ")
                Else
                    _dataSet = Nothing
                End If
            Else
                _dataSet = CType(bsTest.DataSource, DataSet)
            End If
            'is there a data member - find the datatable
            If Me.DataMember <> "" Then
                _DataMemberChanged(sender, e)
            End If 'CType(value.GetService(GetType(IDesignerHost)), IDesignerHost)
            If _form Is Nothing Then GetFormInstance()
            If _usercontrol Is Nothing Then GetUserControlInstance()
        End If
    End Sub
    Private Sub _DataMemberChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.DataMemberChanged
        If Me.DataMember = "" Or _dataSet Is Nothing Then
            _dataTable = Nothing
        Else
            'check to see if the Data Member is the name of a table in the dataset
            If _dataSet.Tables(Me.DataMember) Is Nothing Then
                'it must be a relationship instead of a table
                Dim rel As System.Data.DataRelation = _dataSet.Relations(Me.DataMember)
                If Not rel Is Nothing Then
                    _dataTable = rel.ChildTable
                Else
                    Throw New ApplicationException("Invalid Data Member")
                End If
            Else
                _dataTable = _dataSet.Tables(Me.DataMember)
            End If
        End If
    End Sub
    Public Overrides Property Site() As System.ComponentModel.ISite
        Get
            Return MyBase.Site
        End Get
        Set(ByVal value As System.ComponentModel.ISite)
            'runs at design time to initiate ContainerControl
            MyBase.Site = value
            If value Is Nothing Then Return
            ' Requests an IDesignerHost service using Component.Site.GetService()
            Dim service As IDesignerHost = CType(value.GetService(GetType(IDesignerHost)), IDesignerHost)
            If service Is Nothing Then Return
            If Not TryCast(service.RootComponent, Form) Is Nothing Then
                _form = CType(service.RootComponent, Form)
            ElseIf Not TryCast(service.RootComponent, UserControl) Is Nothing Then
                _usercontrol = CType(service.RootComponent, UserControl)
            End If
        End Set
    End Property
    Public Function GetFormInstance() As System.Windows.Forms.Form
        If _form Is Nothing And Me.CurrencyManager.Bindings.Count > 0 Then
            _form = Me.CurrencyManager.Bindings(0).Control.FindForm()
       
        End If
        Return _form
    End Function
    
    ''' <summary>
    ''' Returns the First Instance of the specified User Control
    ''' </summary>
    ''' <returns>System.Windows.Forms.Control</returns>
    Public Function GetUserControlInstance() As System.Windows.Forms.Control
    	If _usercontrol Is Nothing And Me.CurrencyManager.Bindings.Count > 0 Then
    		Dim _uControls() As System.Windows.Forms.Control
    		_uControls = Me.CurrencyManager.Bindings(0).Control.FindForm.Controls.Find(Me.Site.Name.ToString(), True)
    		_usercontrol = _uControls(0)
    		
        End If
        Return _usercontrol
    End Function
    '============================================================================
    'Private Sub _PositionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Me.PositionChanged
    '    If IsCurrentDirty Then
    '        If AutoSave Then  ' IsAutoSavingEvent
    '            Try
    '                'cast table as ITableUpdate to get the Update method
    '                '  CType(_dataTable, ITableUpdate).Update()
    '            Catch ex As Exception
    '               ' - needs to raise an event 
    '            End Try
    '        Else
    '            Me.CancelEdit()
    '            _dataTable.RejectChanges()
    '        End If
    '        IsCurrentDirty = False
    '    End If
    'End Sub
    #End Region
