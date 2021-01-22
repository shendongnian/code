    <% var itemList = Model.ToList(); %>
    <table>
    <% for (int i=0; i < itemList.Count; i+=2))
       { %>
       <tr>
            <td>
              <%= Html.Encode(itemList[i].PartNo) %>
           </td>
           <td>
              <% if (i+1 < itemList.Count) 
                 { 
                     Response.Write(Html.Encode(itemList[i+1].PartNo));
                 }
               %>
           </td>
       </tr>
    <% } %>
    </table>
