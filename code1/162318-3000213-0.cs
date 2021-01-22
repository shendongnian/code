    <ComClass(ComClass1.ClassId, ComClass1.InterfaceId, ComClass1.EventsId)> _
    Public Class ComClass1
    
    #Region "COM GUIDs"
        ' These  GUIDs provide the COM identity for this class 
        ' and its COM interfaces. If you change them, existing 
        ' clients will no longer be able to access the class.
        Public Const ClassId As String = "eaf83044-f0a7-417b-b333-e45aec398ca5"
        Public Const InterfaceId As String = "84e0fb8f-266d-40e6-9e8c-3d4eb37d3bf0"
        Public Const EventsId As String = "22ea2214-032f-4eb6-b2d4-c5dd213bab87"
    #End Region
    
        ' A creatable COM class must have a Public Sub New() 
        ' with no parameters, otherwise, the class will not be 
        ' registered in the COM registry and cannot be created 
        ' via CreateObject.
        Public Sub New()
            MyBase.New()
        End Sub
    
    End Class
