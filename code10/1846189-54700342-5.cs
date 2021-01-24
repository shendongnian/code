    public class Person
    {
        public string Name { get; set; }
    }
    public List<Person> Exec()
    {
        var persons = new List<Person>();
        var results = New DataTable();
        // methodToExecuteSP is = public DataSet 
        results = methodToExecuteSP;
        foreach (DataRow row in results.Rows)
        {
            result.Add(new Person { Name = row[“Name”].ToString() });
        }
        return persons;
    }
    <tbody>
    <% foreach (var person in Exec()) { %>
        <tr><td><%=person.Name %> </td></tr>
    <% } %>
    </tbody>
