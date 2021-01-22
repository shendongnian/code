    Sub ResizeTabs()
        Dim numTabs = cTabControl.TabCount
        Dim totLen As Decimal = 0
        Using g As Graphics = CreateGraphics()
            ' Get total length of the text of each Tab name
            For i As Integer = 0 To numTabs - 1
                totLen += g.MeasureString(cTabControl.TabPages(i).Text, cTabControl.Font).Width
            Next
        End Using
        Dim newX As Integer = ((cTabControl.Width - totLen) / numTabs) / 2
        cTabControl.Padding = New Point(newX, cTabControl.Padding.Y)
    End Sub
