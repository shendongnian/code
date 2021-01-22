    <%@ Import Namespace="System.Web.Mvc.Html" %>
    <%
    string displayText = string.Empty;
    if (Model != null)
    {
        if (DateTime.Parse(Model.ToString()) != DateTime.MinValue)
            displayText = DateTime.Parse(Model.ToString()).ToShortDateString();
    }
    %>
    <%= Html.TextBox("", displayText, new { @class = "date-box" })%>
