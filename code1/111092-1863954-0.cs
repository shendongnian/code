         Protected Overrides Sub OnDrawItem(ByVal e As System.Windows.Forms.DrawItemEventArgs)
            MyBase.OnDrawItem(e)
            //Don't draw the custom area if in DesignMode.
            If Me.DesignMode Then Return
            //Don't draw the custom area if the index is -1.
            If e.Index = -1 Then Return
            e.DrawBackground()
            Dim boundsRect As Rectangle = e.Bounds
            //Shift everything just a bit to the right.
            Dim lastRight As Integer = 2
            Dim brushForeColor As Color
            Dim bckColor As Color
            Dim lineColor As Color
            If Not (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
               //Item is not selected, use _BackColorOdd and _BackColorEven.
               If e.Index Mod 2 = 0 Then
                  bckColor = _BackColorEven
               Else
                  bckColor = _BackColorOdd
               End If
               //Use black text color.
               brushForeColor = Color.Black
               //Use dark line color.
               lineColor = _BackColorSelected
            Else
               //Item is selected, use the 'Selected' background color.
               bckColor = _BackColorSelected
               //Item is selected, use white font color.
               brushForeColor = Color.White
               //Use white line color.
               lineColor = Color.White
            End If
            //Draw the background rectangle with the appropriate color.
            Using brushBackColor As New SolidBrush(bckColor)
               e.Graphics.FillRectangle(brushBackColor, e.Bounds)
            End Using
            Using linePen As New Pen(lineColor)
               Using brsh As New SolidBrush(brushForeColor)
                  //This is the multi-column stuff.
                  For colIndex As Integer = 0 To _ColumnNames.Count - 1
                     //Variant(Object) type used to support different data types in each column.
                     Dim itm As Object
                     itm = FilterItemOnProperty(Items(e.Index), _ColumnNames(colIndex))
                     boundsRect.X = lastRight
                     boundsRect.Width = _ColumnWidths(colIndex)
                     lastRight = boundsRect.Right
                    
                        e.Graphics.DrawString(itm, Me.Font, brsh, boundsRect)
                     
                     //Draw a divider line.
                     If colIndex < _ColumnNames.Count - 1 Then
                        e.Graphics.DrawLine(linePen, boundsRect.Right, boundsRect.Top, _
                                            boundsRect.Right, boundsRect.Bottom)
                     End If
                  Next
               End Using
            End Using
         End Sub
