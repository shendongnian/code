		Public Shared Function EnumToDropDownList(Of TEnum As Structure)() As System.Web.UI.WebControls.ListItem()
			Dim enumerationType As System.Type = GetType(TEnum)
			If Not enumerationType.IsEnum Then Throw New ArgumentException("Enumeration type is expected.")
			Dim saveResponseTypeNames() As String = System.Enum.GetNames(enumerationType)
			Dim saveResponseTypeValues = System.Enum.GetValues(enumerationType)
			Dim outputListItems(saveResponseTypeNames.Length - 1) As System.Web.UI.WebControls.ListItem
			For i = 0 To saveResponseTypeNames.Length - 1
				outputListItems(i) = New System.Web.UI.WebControls.ListItem(saveResponseTypeNames(i), saveResponseTypeValues(i).ToString())
			Next
			Return outputListItems
		End Function
