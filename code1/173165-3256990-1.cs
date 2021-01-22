	Public NotInheritable Class EnumProcType
		Inherits AbstractTypeSafeEnum
		Public Shared ReadOnly CREATE As New EnumProcType("Création")
		Public Shared ReadOnly MODIF As New EnumProcType("Modification")
		Public Shared ReadOnly DELETE As New EnumProcType("Suppression")
		Private Sub New(ByVal name As String)
			MyBase.New(name)
		End Sub
	End Class
