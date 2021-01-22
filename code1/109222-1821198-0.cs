    foreach (var item in list.GroupBy(u => new {u.Surname, u.FirstName}))
    {
        %>
        <%=Html.Encode(item.Key.FirstName)%>
        <%=Html.Encode(item.Key.Surname)%>
        <%
        if (item.Count) > 1)
        {
            %>
            (<%=item.Count%>)
            <%
        }
    }
