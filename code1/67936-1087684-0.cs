    Class MyUserControlA
    'Inherits UserControl '(This line will be in your desinger file)
    
    Delegate Sub SomethingEventHandler (sender as object, e as EventArgs)  '(assumes you are not going to override event args)
    
    Public Event SomethingEvent as SomethingEventHandler
    
    private _someData as String
    Public Readonly Property MyDataGrid as DataGridView
        Get
            Return DataGridView1  ' this is in the designer form of the user control
        End Get
    
    Public Property SomeData as string
        Get
            return _someData
        End Get
        Set(value as string)
            _someData as string
        End Set
    End Property
    
    Protected Sub OnSomethingEvent()
        RaiseEvent SomethingEvent(Me, EventArgs())
    End Sub
    
    '....something happens and you want to raise the event
    OnSomethingEvent
    
    End Class
