    Public Interface Xyz
        WriteOnly Property AA As String
    End Interface
    Public Class VerifySyntax
        <Fact()>
        Public Sub ThisIsHow()
            Dim xyz = New Mock(Of Xyz)
            xyz.Object.AA = "bb"
            ' Throws:
            xyz.VerifySet(Sub(s) s.AA = It.IsAny(Of String)(), Times.Never())
        End Sub
    End Class
    Public Class SetupSyntax
        <Fact()>
        Public Sub ThisIsHow()
            Dim xyz = New Mock(Of Xyz)
            xyz.SetupSet(Sub(s) s.AA = It.IsAny(Of String)()).Throws(New InvalidOperationException())
            Assert.Throws(Of InvalidOperationException)(Sub() xyz.Object.AA = "bb")
        End Sub
    End Class
