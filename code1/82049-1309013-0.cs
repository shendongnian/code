    Response.Write(@"<br>System.Guid.NewGuid().ToString() = " + System.Guid.NewGuid().ToString());
    Response.Write(@"<br>System.Guid.NewGuid().ToString(""N"") = " + System.Guid.NewGuid().ToString("N"));
    Response.Write(@"<br>System.Guid.NewGuid().ToString(""D"") = " + System.Guid.NewGuid().ToString("D"));
    Response.Write(@"<br>System.Guid.NewGuid().ToString(""B"") = " + System.Guid.NewGuid().ToString("B"));
    Response.Write(@"<br>System.Guid.NewGuid().ToString(""P"") = " + System.Guid.NewGuid().ToString("P"));
