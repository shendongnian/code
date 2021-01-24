    Private Const MaxPoints As Long = 100
    
    Private Sub CommandButton1_Click()
        Dim i As Long, PI As Double
        PI = 4 * Atn(1)
        For i = 1 To 720 / 5
            AddValueToChart 50# + 35# * Sin(5 * i * PI / 180)
            DoEvents
        Next i
    End Sub
    
    Public Sub AddValueToChart(ByVal x As Double)
        Dim ch As Chart, list() As Variant
        Set ch = Me.ChartObjects("Chart 1").Chart
        
        Dim serlist As SeriesCollection
        Set serlist = ch.SeriesCollection()
        ' If chart is empty then add a line with 100 points
        If serlist.Count = 0 Then
            serlist.NewSeries
            ReDim list(1 To MaxPoints)
            ch.SeriesCollection(1).Values = list
        End If
        
        Dim ser As Series
        Set ser = ch.SeriesCollection(1)
        ' Get an array of values
        list = ser.Values
        Dim i As Long
        For i = MaxPoints To 2 Step -1
            ' Shift points
            list(i) = list(i - 1)
        Next i
        ' Add a new point to the begining of the chart.
        list(1) = x
        ' Assign the modified list as values of the series.
        ser.Values = list
    End Sub
