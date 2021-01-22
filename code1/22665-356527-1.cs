	Public Function GetProperties() As PropertyDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetProperties
		Dim baseProps As PropertyDescriptorCollection = TypeDescriptor.GetProperties(Me, True)
		Dim LocalizedProps As PropertyDescriptorCollection = New PropertyDescriptorCollection(Nothing)
		Dim oProp As PropertyDescriptor
		For Each oProp In baseProps
			LocalizedProps.Add(New LocalizedPropertyDescriptor(oProp))
		Next
		Return LocalizedProps
	End Function
