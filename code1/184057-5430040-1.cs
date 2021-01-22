		private void w8(Action action)
		{
			Cursor.Current = Cursors.WaitCursor;
			Application.DoEvents();
			action();
			Cursor.Current = Cursors.Default;
		}
    Public Class DamnLogin
    	Private db As FRIIB
    
    	Public Sub New(ByVal connection As String)
    		db = New FRIIB(connection)
    	End Sub
    
    	Public Function Login(ByVal name As String, ByVal password As String) As Boolean
    		Dim GetUser = _
    		   From u In db.GetTable(Of [User])() _
    		   Where u.Name = name _
    		   And u.Password = password _
    		   Select u
    		Return GetUser.Count = 0
    	End Function
    End Class
    let Login usename password = 
        new LinqBase.DamnLogin(insql) |> fun damn ->
            not <| damn.Login(usename,password)
