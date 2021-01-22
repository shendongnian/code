    Namespace MailTemplates
      Public Class Templates
        Public Shared ReadOnly Property PurchaseReceipt(Caller As TemplateControl) As PurchaseReceipt
          Get
            Return BaseTemplate.GetTemplate(Caller, GetType(PurchaseReceipt))
          End Get
        End Property
      End Class
    End Namespace
