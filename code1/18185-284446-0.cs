    Imports System.threading 
    Imports System.Runtime.InteropServices 
    Imports System.Windows.Forms
    
    
    Public Class Class1
    
        <System.STAThread()> _
            Public Shared Sub Main()
    
            Try
                System.Windows.Forms.Application.EnableVisualStyles()
                System.Windows.Forms.Application.DoEvents()
                System.Windows.Forms.Application.Run(New Class2)
            Catch invEx As Exception
    
                Application.Exit()
    
            End Try
    
    
        End Sub 'Main End Class 
