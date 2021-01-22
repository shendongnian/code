	Public MustInherit Class AbstractTypeSafeEnum
		Private Shared ReadOnly syncroot As New Object
		Private Shared masterValue As Integer = 0
		Protected ReadOnly _name As String
		Protected ReadOnly _value As Integer
		Protected Sub New(ByVal name As String)
			Me._name = name
			SyncLock syncroot
				masterValue += 1
				Me._value = masterValue
			End SyncLock
		End Sub
		Public ReadOnly Property value() As Integer
			Get
				Return _value
			End Get
		End Property
		Public Overrides Function ToString() As String
			Return _name
		End Function
		Public Shared Operator =(ByVal ats1 As AbstractTypeSafeEnum, ByVal ats2 As AbstractTypeSafeEnum) As Boolean
			Return (ats1._value = ats2._value) And Type.Equals(ats1.GetType, ats2.GetType)
		End Operator
		Public Shared Operator <>(ByVal ats1 As AbstractTypeSafeEnum, ByVal ats2 As AbstractTypeSafeEnum) As Boolean
			Return Not (ats1 = ats2)
		End Operator
	End Class
