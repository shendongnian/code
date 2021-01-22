	<Extension()>
	Public Function DecendentControls(ParentControl As Control) As Control()
		Dim controls As New List(Of Control)
		For Each myControl As Control In ParentControl.Controls
			controls.Add(myControl)
			controls.AddRange(myControl.DecendentControls)
		Next
		Return controls.ToArray
	End Function
