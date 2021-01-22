    Public Interface IPrivateField
        Function GetDirty() As Boolean
    End Interface
    
    Public Interface IPublicField
        Inherits IPrivateField
    
        Sub SetIsDirty(ByVal dirty As Boolean)
    End Interface
    
    Public Class Whatever
        Implements IPublicField
    
        Public Function GetDirty() As Boolean Implements IPrivateField.GetDirty
            ' logic here
        End Function
    
        Public Sub SetDirty(ByVal dirty As Boolean) Implements IPublicField.SetIsDirty
            ' logic here
        End Sub
    End Class
