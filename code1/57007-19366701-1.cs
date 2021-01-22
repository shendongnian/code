    Imports System.IO
    Class Program
    
        Private Shared sw As StreamWriter
    
        Private Shared Sub DoSmth()
	        sw.WriteLine("foo")
        End Sub
        Shared Sub Main(ByVal args As String())
            Using sw = New StreamWriter("C:\Temp\data.txt")
                DoSmth()
            End Using
        End Sub
    End Class
