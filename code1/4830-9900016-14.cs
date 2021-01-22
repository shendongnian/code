	Namespace CustomExtensions
		Public Module ListItemCollectionExtension
	
			<Runtime.CompilerServices.Extension()> _
			Public Sub AddEnum(Of TEnum As Structure)(items As System.Web.UI.WebControls.ListItemCollection)
				Dim enumerationType As System.Type = GetType(TEnum)
				Dim enumUnderType As System.Type = System.Enum.GetUnderlyingType(enumType)
	
				If Not enumerationType.IsEnum Then Throw New ArgumentException("Enumeration type is expected.")
	
				Dim enumTypeNames() As String = System.Enum.GetNames(enumerationType)
				Dim enumTypeValues() As TEnum = System.Enum.GetValues(enumerationType)
	
				For i = 0 To enumTypeNames.Length - 1
					items.Add(New System.Web.UI.WebControls.ListItem(saveResponseTypeNames(i),  Convert.ChangeType(enumTypeValues(i), enumUnderType).ToString()))
				Next
			End Sub
		End Module
	End Namespace
