    void Main()
    {
        var CodelistValueView = new data[] {
            new data() {TableName = "1", Namespace="UDP"},
            new data() {TableName = "1", Namespace="REFDAT"},
            new data() {TableName = "2", Namespace="UDP"},
            new data() {TableName = "3", Namespace="REFDAT"},
            new data() {TableName = "4", Namespace="UDP"},
            new data() {TableName = "4", Namespace="REFDAT"},
            new data() {TableName = "5", Namespace="other"}
        };
        
        var result =
            from Ref in CodelistValueView
            join udp in CodelistValueView
            on Ref.TableName equals udp.TableName
            where Ref.Namespace == "REFDAT" &&
                  udp.Namespace == "UDP"
            select udp;
        
        result.Dump();
    }
    // Define other methods and classes here
    class data
    {
        public string TableName;
        public string Namespace;
    }
