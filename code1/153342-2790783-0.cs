        Public Class ctrlMessageBox
            Inherits System.Web.UI.UserControl
    
            'List of types that a message could be
            Enum MessageTypes
                InfoMessage
                ErrorMessage
                WarningMessage
            End Enum
    
    #Region "[Message] inner class for structered message object"
            Public Class Message
                Private _messageText As String
                Private _messageType As MessageTypes
                Public Property MessageText() As String
                    Get
                        Return _messageText
                    End Get
                    Set(ByVal value As String)
                        _messageText = value
                    End Set
                End Property
                Public Property MessageType() As MessageTypes
                    Get
                        Return _messageType
                    End Get
                    Set(ByVal value As MessageTypes)
                        _messageType = value
                    End Set
                End Property
    
            End Class
    #End Region
    
            'storage of all message objects
            Private _messages As New List(Of Message)
    
            'Creates a Message object and adds it to the collection
            Public Sub addMessage(ByVal MessageType As MessageTypes, ByVal MessageText As String)
                Page.Trace.Warn(Me.GetType.Name, String.Format("addMessage({0},{1})", MessageType.ToString, MessageText))
                Dim msg As New Message
                msg.MessageText = MessageText
                msg.MessageType = MessageType
                _messages.Add(msg)
            End Sub
    
            Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
                ' Page.Trace.Warn(Me.GetType.Name, String.Format("Page_PreRender(_messages.Count={0})", _messages.Count))
    
            End Sub
            Public Overrides Sub RenderControl(ByVal writer As System.Web.UI.HtmlTextWriter)
                Page.Trace.Warn(Me.GetType.Name, String.Format("ctrlMessageBox.RenderControl(_messages.Count={0})", _messages.Count))
                'draws the message box on the page with all messages
    
                If _messages.Count = 0 Then Return
                Dim sbHTML As New StringBuilder
                sbHTML.Append("<div id='MessageBox'>")
    
                For Each msg As Message In _messages
                    sbHTML.AppendFormat("<p><img src='{0}'> {1}</p>", getImage(msg.MessageType), msg.MessageText)
                Next
    
                sbHTML.Append("</div>")
    
                writer.Write(sbHTML.ToString)
    
                'dim ctrlLiteral As New Literal()
                'ctrlLiteral.Text = sbHTML.ToString
                'Me.Controls.Add(ctrlLiteral)
            End Sub
    
            'returns a specific image based on the message type
            Protected Function getImage(ByVal type As MessageTypes) As String
                Select Case type
                    Case MessageTypes.ErrorMessage
                        Return Page.ResolveUrl("~/images/icons/error.gif")
                    Case MessageTypes.InfoMessage
                        Return Page.ResolveUrl("~/images/icons/icon-status-info.gif")
                    Case MessageTypes.WarningMessage
                        Return Page.ResolveUrl("~/images/icons/icon-exclaim.gif")
                    Case Else
                        Return ""
                End Select
            End Function
        End Class
