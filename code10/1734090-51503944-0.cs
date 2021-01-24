    using Gremlin.Net.CosmosDb.Structure;
    
    [Label("person")]
    public class PersonVertex : VertexBase
    {
        public string Name { get; set; }
    
        public DateTimeOffset Birthdate { get; set; }
    }
    
    var query = g.V<PersonVertex>().Has(v => v.Name, "Todd").Property(v => v.Birthdate, DateTimeOffset.Now);
    var response = await graphClient.QueryAsync(query);
    
    foreach (var vertex in response)
    {
        Console.WriteLine(vertex.Birthdate.ToString());
        Console.WriteLine(vertex.Name);
    }
<!--  -->
