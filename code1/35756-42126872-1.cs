    <%@ Page Language="c#" %>
    <%@ Import namespace="System.IO"%>
    <%
    
    StreamWriter tsw = File.AppendText(@Server.MapPath("./test.txt"));
    tsw.WriteLine("--------------------------------");
    tsw.WriteLine(DateTime.Now.ToString());
     
    tsw.Close();
    %>
    
    Done
