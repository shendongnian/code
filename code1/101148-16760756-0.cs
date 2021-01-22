    Friend Structure PointStruct
        Public x As Int32
        Public y As Int32
    End Structure
    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Friend Function WindowFromPoint(ByVal Point As PointStruct) As IntPtr
    End Function
    ''' <summary>
    ''' Checks if a control is actually visible to the user completely
    ''' </summary>
    ''' <param name="control">The control to check.</param>
    ''' <returns>True, if the control is completely visible, false else.</returns>
    ''' <remarks>This is not 100% accurate, but feasible enough for my purpose.</remarks>
    Public Function IsControlVisibleToUser(ByVal control As Windows.Forms.Control) As Boolean
        If Not control.Visible Then Return False
        Dim bAllPointsVisible As Boolean = True
        Dim lPointsToCheck As New List(Of Point)
        'Add the points to check. In this case add the edges and some border points
        'between the edges.
        'Strangely, the exact edge points always return the false handle.
        'So we add a pixel into the control.
        lPointsToCheck.Add(New Point(control.Left + 1, control.Top + 1))
        lPointsToCheck.Add(New Point(control.Right - 1, control.Top + 1))
        lPointsToCheck.Add(New Point(control.Right - 1, control.Bottom - 1))
        lPointsToCheck.Add(New Point(control.Left + 1, control.Bottom - 1))
        lPointsToCheck.Add(New Point(control.Left + control.Width / 2, control.Top + 1))
        lPointsToCheck.Add(New Point(control.Right - 1, control.Top + control.Height / 2))
        lPointsToCheck.Add(New Point(control.Right - control.Width / 2, control.Bottom - 1))
        lPointsToCheck.Add(New Point(control.Left + 1, control.Bottom - control.Height / 2))
        'lPointsToCheck.Add(New Point(control.Left + control.Width / 2, control.Top + control.Height / 2))
        'Check each point. If all points return the handle of the control,
        'the control should be visible to the user.
        For Each oPoint In lPointsToCheck
            Dim sPoint As New PointStruct() With {
                .x = oPoint.X, _
                .y = oPoint.Y _
            }
            bAllPointsVisible = bAllPointsVisible And ( _
                (WindowFromPoint(sPoint) = control.Handle) _
            )
        Next
        Return bAllPointsVisible
    End Function
