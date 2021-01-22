        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id = item.Id })%>
                |
                <%= Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%>
            </td>
            <td>
                <%= Html.Encode(item.Id)%>
            </td>
            <td>
                <%= Html.Encode(item.FirstName)%>
            </td>
            <td>
                <%= Html.Encode(item.LastName)%>
            </td>
            <td>
                <%= Html.Encode(item.Phone)%>
            </td>
            <td>
                <%= Html.Encode(item.Email)%>
            </td>
            <td ondblclick="editStatus(this,<%=item.Id %>, <%= item.Status.GetHashCode() %>);">
                <%= item.Status== Status.Active ? "Active" :"Inactive" %>
            </td>
        </tr>
        <% } %>
    </table>
    <input type="submit" id="refresh" style="display:none" />
