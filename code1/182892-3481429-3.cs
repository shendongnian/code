    public class EmailMessage
    {
         [DisplayName("First Name")]
         public string FirstName { get; set; }
         public string LastName { get; set; }
         public string Email { get; set; }
         ....
    }
    <% using (Html.BeginForm()) { %>
        <%: LabelFor(m => m.FirstName) %><%: EditorFor(m => m.FirstName) %>
        <%: LabelFor(m => m.LastName) %><%: EditorFor(m => m.LastName) %>
        <%: LabelFor(m => m.Email) %><%: EditorFor(m => m.Email) %>
    <% } %>
