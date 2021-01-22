        string a = "<%@ Page Language=\"C#\" MasterPageFile=\"~/Views/Shared/Site.Master\" Inherits=\"System.Web.Mvc.ViewPage\" %>";
        Regex r = new Regex("MasterPageFile=\"([^\"]*)\"", RegexOptions.Compiled);
        Match m = r.Match(a);
        if (m.Success)
        {
           // what you want is in m.Groups[1]
        }
