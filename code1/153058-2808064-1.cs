    Public Class tProductValidator
	Inherits AbstractValidator(Of tProduct)
	Public Sub New()
		Const RetailWholsaleError As String = "You need to enter either a Retail Price (final price to user) or a Wholesale Price (price sold to us), but not both."
		Dim CustomValidation As System.Func(Of tProduct, ValidationFailure) =
		 Function(x)
			 If (x.RetailPrice Is Nothing AndAlso x.WholesalePrice Is Nothing) OrElse (x.RetailPrice IsNot Nothing AndAlso x.WholesalePrice IsNot Nothing) Then
				 Return New ValidationFailure("RetailPrice", RetailWholsaleError)
			 End If
			 Return Nothing
		 End Function
		Custom(CustomValidation)
    End Sub
    
    End Class
