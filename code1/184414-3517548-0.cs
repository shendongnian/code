    <%@ Page Inherits="MyPage" MasterPageFile="~/Master.master" %>
    <%@ Import Namespace = "System.Linq" %>
    <script language="C#" runat="server">
    [System.Web.Services.WebMethod]
    public static List<string> GetA()
    {
        MyDataContext db = new MyDataContext();
    
        var result = from a in db.A
                     select a;
    
        return result.ToList();
    
    }
    </script>
