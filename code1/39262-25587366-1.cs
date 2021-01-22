    Namespace MailTemplates
      Public MustInherit Class BaseTemplate
        Inherits UserControl
        Public Shared Function GetTemplate(Caller As TemplateControl, Template As Type) As BaseTemplate
          Return Caller.LoadControl("~/MailTemplates/{0}.ascx".ToFormat(Template.Name))
        End Function
        Public Sub InjectCss(FileName As String)
          If Me.Styler IsNot Nothing Then
            Me.Styler.Controls.Add(New Controls.Styler(FileName))
          End If
        End Sub
        Private ReadOnly Property Styler As PlaceHolder
          Get
            If _Styler Is Nothing Then
              _Styler = Me.FindNestedControl(GetType(PlaceHolder))
            End If
            Return _Styler
          End Get
        End Property
        Private _Styler As PlaceHolder
      End Class
    End Namespace
