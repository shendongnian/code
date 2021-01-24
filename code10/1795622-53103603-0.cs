    void Main()
    {
        //var graphClient = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "neo");
        var graphClient = new BoltGraphClient("bolt://localhost:7687", "neo4j", "neo");
        graphClient.Connect();
        
        graphClient.Cypher.Match("(n)").DetachDelete("n").ExecuteWithoutResults();
        
        List<TravelEdge> travelpoints = new List<TravelEdge>{
            new TravelEdge { Id1 = 1, Id2 = 2, TravelTime = new DateTime(2000,1,1) },
            new TravelEdge { Id1 = 2, Id2 = 3, TravelTime = new DateTime(2000,1,2) },
            new TravelEdge { Id1 = 3, Id2 = 4, TravelTime = new DateTime(2000,1,3) },
            new TravelEdge { Id1 = 4, Id2 = 5, TravelTime = null },
        };
        
        var ids = new [] {1,2,3,4,5};
        graphClient.Cypher
            .Unwind(ids, "id")
            .Merge("(a:Node {Id: id})")
            .ExecuteWithoutResults();
        
        
        
        //Add stuff to list
        graphClient.Cypher
            .Unwind(travelpoints, "sc")
            .Match("(s1:Node { Id: sc.Id1})")
            .Match("(s2:Node { Id: sc.Id2})")
            .Merge("(s1)-[t:Travels_To]->(s2)")
            .OnCreate()
            .Set("t.Time = sc.TravelTime")
            .ExecuteWithoutResults();
    }
    
    
    public class Node{
        public long Id {get;set;}
    }
    
    public class TravelEdge {
        public long Id1 {get;set;}
        public long Id2 {get;set;}
        public DateTime? TravelTime {get;set;}
    }
