    Public Sub CopyChartImageToClipBoard(ByVal ChartToSave As Chart)
        Dim originalSize As Size = ChartToSave.Size
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim cloneChart As New Chart
        Using ms As New IO.MemoryStream()
            Try
                'cloneChart = CType(ChartToSave.Clone, Chart)
                cloneChart = CloneMSChart(ChartToSave)
                cloneChart.Size = New Size(screenWidth, screenHeight)   ' copy a high resolution image 
                cloneChart.SaveImage(ms, System.Drawing.Imaging.ImageFormat.Png)
                ms.Seek(0, SeekOrigin.Begin)
                Using mf As New Bitmap(ms)
                    Clipboard.SetImage(mf)
                End Using
            Finally
                ms.Close()
                cloneChart.Dispose()
            End Try
        End Using
    End Sub
'------------------------------------------------------------
    Public Function CloneMSChart(ByVal chart1 As Chart) As Chart
        Dim myStream As New System.IO.MemoryStream
        Dim chart2 As Chart = New Chart
        chart1.Serializer.Save(myStream)
        chart2.Serializer.Load(myStream)
        Return chart2
    End Function
