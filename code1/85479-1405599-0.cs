        ''' <summary>
        ''' Gets or sets the object used to marshal the event handler calls issued as a result of finding a file in a search.
        ''' </summary>
        <IODescription(SR.FSS_SynchronizingObject), DefaultValue(CType(Nothing, String))> _
        Public Property SynchronizingObject() As System.ComponentModel.ISynchronizeInvoke
            Get
                If (_synchronizingObject Is Nothing) AndAlso (MyBase.DesignMode) Then
                    Dim oHost As IDesignerHost = DirectCast(MyBase.GetService(GetType(IDesignerHost)), IDesignerHost)
                    If (Not (oHost Is Nothing)) Then
                        Dim oRootComponent As Object = oHost.RootComponent
                        If (Not (oRootComponent Is Nothing)) AndAlso (TypeOf oRootComponent Is ISynchronizeInvoke) Then
                            _synchronizingObject = DirectCast(oRootComponent, ISynchronizeInvoke)
                        End If
                    End If
                End If
                Return _synchronizingObject
            End Get
            Set(ByVal Value As System.ComponentModel.ISynchronizeInvoke)
                _synchronizingObject = Value
            End Set
        End Property
        Private _onStartupHandler As EventHandler
        Protected Sub OnStartup(ByVal e As EventArgs)
            If ((Not Me.SynchronizingObject Is Nothing) AndAlso Me.SynchronizingObject.InvokeRequired) Then
                Me.SynchronizingObject.BeginInvoke(_onStartupHandler, New Object() {Me, e})
            Else
                _onStartupHandler.Invoke(Me, e)
            End If
        End Sub
