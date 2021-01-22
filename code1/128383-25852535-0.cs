    protected void build_Menu() 
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<li><a href='" + VirtualPathUtility.ToAbsolute("~/Default.aspx'>Home</a></li>"));
        sb.Append("<li><a href='" + VirtualPathUtility.ToAbsolute("~/CARS/Default.aspx'>Cars</a></li>"));
        sb.Append("<li><a href='" + VirtualPathUtility.ToAbsolute("~/AIRPLANES/Default.aspx'>Airplanes</a></li>"));
        sb.Append("<li><a href='" + VirtualPathUtility.ToAbsolute("~/MOTORCYCLES/Default.aspx'>Motorcycles</a></li>"));
        sb.Append("<li><a href='" + VirtualPathUtility.ToAbsolute("~/REPORTS/Default.aspx'>Reports</a></li>"));
        sb.Append("<li><a href='" + VirtualPathUtility.ToAbsolute("~/MANUALS/Default.aspx'>Manuals</a> </li>"));
        sb.Append("<li><a href='" + VirtualPathUtility.ToAbsolute("~/ADMINISTRATION/Default.aspx'>Administration</a></li>"));
        MENUfromCodeBehind.Text = sb.ToString();
    }
