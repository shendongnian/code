    <%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ITrustGrid<EmployeeInfoDTO>>" %>
    <table>
        <thead>
            <tr>
                <%
                    foreach (string header in Model.Headers)
                        Response.Write(Html.Th(header));
                %>
            </tr>
        </thead>
        <tbody>
            <%
                foreach (var element in Model.Elements)
                {
                    Response.Write("<tr>");
                    foreach (var column in Model.Columns)
                        Response.Write(Html.Td(column.ValueExpression(element)));
                    Response.Write("</tr>");
                }
            %>
        </tbody>
    </table>
    <div class="pager">
        <%= Html.Pager(Model.Elements.PageSize, Model.Elements.PageNumber, Model.Elements.TotalItemCount)%>
    </div>
