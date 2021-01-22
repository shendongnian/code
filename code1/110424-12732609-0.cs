    Public Class MyEFDataContainerLocal
       Inherits MyEFDataContainer
        Public Sub New()
            MyBase.New(My.Settings.MyEFContainerConnectionString)
        End Sub
    End Class
