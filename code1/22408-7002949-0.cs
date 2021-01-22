    Public Class ExcelHlpr
    
        Declare Function EndTask Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal ShutDown As Boolean, ByVal Force As Boolean) As Integer
    
        Dim cXlApp As Microsoft.Office.Interop.Excel.Application
    
        Public Function GetExcel() As Microsoft.Office.Interop.Excel.Application
            cXlApp = New Microsoft.Office.Interop.Excel.Application
            Return cXlApp
        End Function
    
        Public Function EndExcel() As Integer
            Dim xlHwnd As New IntPtr(cXlApp.Hwnd)
            Return EndTask(xlHwnd, False, True)
        End Function
    
    End Class
