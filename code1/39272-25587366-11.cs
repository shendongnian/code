    Namespace MailTemplates
      Public MustInherit Class PurchaseReceipt
        Inherits BaseTemplate
        Public MustOverride WriteOnly Property Name As String
        Public MustOverride WriteOnly Property OrderTotal As Decimal
        Public MustOverride WriteOnly Property OrderDescription As String
      End Class
    End Namespace
