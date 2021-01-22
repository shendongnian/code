    Public MustInherit Class SuperTableAdapter
        Inherits System.ComponentModel.Component
    
        Public MustOverride ReadOnly Property MyCommandCollection As Data.SqlClient.SqlCommand()
        Public Sub New()
            MyBase.New()
            'With the command collection exposed, you can replace it with your own.  You can do the same for events.'
    
            For i = 0 To MyCommandCollection.Length - 1
                 Dim myspecialCommand As New Data.SqlClient.SqlCommand()
                MyCommandCollection(i) = myspecialCommand
            Next
        End Sub
    End Class
    
