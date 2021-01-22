        <ComVisible(False)> _
        Public Function AppendLine(ByVal value As String) As StringBuilder
            Me.Append(value)
            Return Me.Append(Environment.NewLine)
        End Function
        Public Shared ReadOnly Property NewLine As String
            Get
                Return ChrW(13) & ChrW(10)
            End Get
        End Property
