    Partial Class PurchaseReceipt
      Inherits MailTemplates.PurchaseReceipt
      Public Overrides WriteOnly Property Name As String
        Set(Value As String)
          lblName.Text = Value
        End Set
      End Property
      Public Overrides WriteOnly Property OrderTotal As Decimal
        Set(Value As Boolean)
          lblOrderTotal.Text = Value
        End Set
      End Property
      Public Overrides WriteOnly Property OrderDescription As Decimal
        Set(Value As Boolean)
          lblOrderDescription.Text = Value
        End Set
      End Property
    End Class
