    Dim xl As New Excel.Application
        xl.DisplayAlerts = False
        xl.Workbooks.Open("<FilePath>", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, _
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
        Dim sheet As Excel.Worksheet
        Dim ws
        Try
            For Each ws In xl.ActiveWorkbook.Worksheets
                ws.Select(Type.Missing)
                With ws.PageSetup
                    .PaperSize = Excel.XlPaperSize.xlPaperA4
                    .Orientation = Excel.XlPageOrientation.xlLandscape
                    .Zoom = 80
                    .BottomMargin = 0.25
                    .LeftMargin = 0.25
                    .RightMargin = 0.25
                    .TopMargin = 0.25
                    .FitToPagesWide = 1
                End With
                ws.PrintOut(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
            Next
        Catch exp As Exception
            MsgBox("Unable to setup printing properties for the sheet." & Chr(13) & "Check if you have printer installed on your machine.", MsgBoxStyle.OKOnly)
        Finally
            xl.Workbooks.Close()
            xl.Quit()
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(xl) > 0)
                ''do nothing
            End While
            xl = Nothing
        End Try
