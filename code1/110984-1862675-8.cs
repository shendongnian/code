    void Main()
    {
        var CodelistValueView = new data[] {
            new data() {TableName = "1", Namespace="UDP", TableID=1},
            new data() {TableName = "1", Namespace="REFDAT", TableID=1},
            new data() {TableName = "2", Namespace="UDP", TableID=3},
            new data() {TableName = "3", Namespace="REFDAT", TableID=4},
            new data() {TableName = "4", Namespace="UDP", TableID=1},
            new data() {TableName = "4", Namespace="REFDAT", TableID=1},
            new data() {TableName = "5", Namespace="other", TableID=5},
            new data() {TableName = "6", Namespace="UDP", TableID=2},
            new data() {TableName = "6", Namespace="REFDAT", TableID=2}
        };
        
        var result =
            from Ref in CodelistValueView
            join udp in CodelistValueView
            on Ref.TableName equals udp.TableName
            where Ref.Namespace == "REFDAT" &&
                  udp.Namespace == "UDP"
            select udp.TableID;
        
        result.Distinct().Dump();
    }
    // Define other methods and classes here
    class data
    {
        public string TableName;
        public string Namespace;
        public int TableID;
    }
