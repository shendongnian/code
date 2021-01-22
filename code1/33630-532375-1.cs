    Public Class Form1
    
        Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        End Sub
    
        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Dim S As ISimpleInterface
            Dim Ext As IExtendedInterface
            Dim F As New Foo
            F.ErrorMsg = "Test Error"
            S = F
            Ext = F
            MsgBox(S.ErrorMsg)
            MsgBox(Ext.ErrorMsg)
            MsgBox(F.ErrorMsg)
        End Sub
    End Class
    
    
    Public Interface ISimpleInterface
        ReadOnly Property ErrorMsg() As String
    End Interface
    
    Public Interface IExtendedInterface
        Property ErrorMsg() As String
        Property SomeOtherProperty() As String
    End Interface
    
    Public Class Foo
        Implements ISimpleInterface, IExtendedInterface
        Private other As String
        Private msg As String
    
        Public Property ErrorMsg() As String Implements IExtendedInterface.ErrorMsg
            Get
                Return msg
            End Get
            Set(ByVal value As String)
                msg = value
            End Set
        End Property
    
        Public Property SomeOtherProperty() As String Implements IExtendedInterface.SomeOtherProperty
            Get
                Return other
            End Get
            Set(ByVal value As String)
                other = value
            End Set
        End Property
    
        Private ReadOnly Property ErrorMsgSimple() As String Implements ISimpleInterface.ErrorMsg
            Get
                Return ErrorMsg
            End Get
        End Property
    End Class
