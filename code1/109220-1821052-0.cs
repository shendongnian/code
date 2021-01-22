      <% 
       Dictionary<string,int> counts = new Dictionary<string, int>();
       foreach (User usedBy in discountDto.UsedBy)   
       { %>
            <%if (counts.Contains(usedBy.FullName)) counts[usedBy.FullName]++; 
              else counts.Add(usedBy.FullName, 1);       
       } %>
       <% foreach(string usdBy in counts)
       { %> 
          <%=usedBy.FullName%><br /><% 
       } %>
     
