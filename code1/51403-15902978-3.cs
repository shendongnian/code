	Public Class Cloning
		Public Shared Function DeepClone(Of T)(ByVal obj As T) As T
			Using MStrm As New MemoryStream(100)	' Create a memory stream.
				' Create a binary formatter:
				Dim BF As New BinaryFormatter(Nothing, New StreamingContext(StreamingContextStates.Clone))
				BF.Serialize(MStrm, obj)	' Serialize the object into MStrm.
				' Seek the beginning of the stream, and then deserialize MStrm:
				MStrm.Seek(0, SeekOrigin.Begin)
				Return CType(BF.Deserialize(MStrm), T)
			End Using
		End Function
	End Class
