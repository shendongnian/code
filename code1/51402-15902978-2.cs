	Public Class C
	Implements ICloneable
		Dim a As Integer
		' Reference-type fields:
		Dim d As D
		Dim e As E
		Private Function Clone() As Object Implements System.ICloneable.Clone
			' Shallow copy:
			Dim copy As C = CType(Me.MemberwiseClone, C)
			' Deep copy: Copy the reference types of this object:
			If copy.d IsNot Nothing Then copy.d = CType(d.Clone, D)
			If copy.e IsNot Nothing Then copy.e = CType(e.Clone, E)
			Return copy
		End Function
	End Class
	Public Class D
	Implements ICloneable
		Public Function Clone() As Object Implements System.ICloneable.Clone
			Return Me.MemberwiseClone()
		End Function
	End Class
	Public Class E
	Implements ICloneable
		Public Function Clone() As Object Implements System.ICloneable.Clone
			Return Me.MemberwiseClone()
		End Function
	End Class
