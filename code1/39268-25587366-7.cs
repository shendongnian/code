    '
    ' FindNestedControl helpers based on tip by @andleer
    ' at http://stackoverflow.com/questions/619449/
    '
    Public Module Helpers
      <Extension>
      Public Function AllControls(Control As Control) As List(Of Control)
        Return Control.Controls.Flatten
      End Function
      <Extension>
      Public Function FindNestedControl(Control As Control, Id As String) As Control
        Return Control.Controls.Flatten(Function(C) C.ID = Id).SingleOrDefault
      End Function
      <Extension>
      Public Function FindNestedControl(Control As Control, Type As Type) As Control
        Return Control.Controls.Flatten(Function(C) C.GetType = Type).SingleOrDefault
      End Function
      <Extension>
      Public Function Flatten(Controls As ControlCollection) As List(Of Control)
        Flatten = New List(Of Control)
        Controls.Traverse(Sub(Control) Flatten.Add(Control))
      End Function
      <Extension>
      Public Function Flatten(Controls As ControlCollection, Predicate As Func(Of Control, Boolean)) As List(Of Control)
        Flatten = New List(Of Control)
        Controls.Traverse(Sub(Control)
                            If Predicate(Control) Then
                              Flatten.Add(Control)
                            End If
                          End Sub)
      End Function
      <Extension>
      Public Sub Traverse(Controls As ControlCollection, Action As Action(Of Control))
        Controls.Cast(Of Control).ToList.ForEach(Sub(Control As Control)
                                                   Action(Control)
                                                   If Control.HasControls Then
                                                     Control.Controls.Traverse(Action)
                                                   End If
                                                 End Sub)
      End Sub
      <Extension()>
      Public Function ToFormat(Template As String, ParamArray Values As Object()) As String
        Return String.Format(Template, Values)
      End Function
      <Extension()>
      Public Function ToHtml(Control As Control) As String
        Dim oSb As StringBuilder
        oSb = New StringBuilder
        Using oSw As New StringWriter(oSb)
          Using oTw As New HtmlTextWriter(oSw)
            Control.RenderControl(oTw)
            Return oSb.ToString
          End Using
        End Using
      End Function
    End Module
    Namespace Controls
      Public Class Styler
        Inherits LiteralControl
        Public Sub New(FileName As String)
          Dim _
            sFileName,
            sFilePath As String
          sFileName = Path.GetFileNameWithoutExtension(FileName)
          sFilePath = HttpContext.Current.Server.MapPath("~/Styles/{0}.css".ToFormat(sFileName))
          If File.Exists(sFilePath) Then
            Me.Text = String.Empty
          Else
            Me.Text = "{0}<style type=""text/css"">{0}{1}</style>{0}".ToFormat(vbCrLf, File.ReadAllText(sFilePath))
          End If
        End Sub
      End Class
    End Namespace
    Public Class Utils
      Public Shared Sub SendMail(Recipient As MailAddress, Subject As String, HtmlBody As String)
        Using oMessage As New MailMessage
          oMessage.To.Add(Recipient)
          oMessage.IsBodyHtml = True
          oMessage.Subject = Subject.Trim
          oMessage.Body = HtmlBody.Trim
          Using oClient As New SmtpClient
            oClient.Send(oMessage)
          End Using
        End Using
      End Sub
    End Class
