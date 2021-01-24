    var groupedObjects = objects.GroupBy(o => (o.monitorName, o.ProcessGUID, o.Apikey, o.AIRSTATION))
        .Select(g => new GroupObject()
                    {
                        monitorName = g.Key.monitorName,
                        ProcessGUID = g.Key.ProcessGUID,
                        Apikey = g.Key.Apikey,
                        AIRSTATION = g.Key.AIRSTATION,
                        list = g.Select(s => new ObjectSubobjects()
                                            {
                                                variableName = s.variableName,
                                                id = s.id,
                                                AIRSTATIONChannel = s.AIRSTATIONChannel
                                            })
                                .ToList()
                    })
        .ToList();
    public class orginalobject
    {
        public string monitorName { get; set; }
        public Guid ProcessGUID { get; set; }
        public Guid Apikey { get; set; }
        public string AIRSTATION { get; set; }
        public string variableName { get; set; }
        public Guid id { get; set; }
        public int AIRSTATIONChannel { get; set; }
    }
    public class GroupObject
    {
        public string monitorName { get; set; }
        public Guid ProcessGUID { get; set; }
        public Guid Apikey { get; set; }
        public string AIRSTATION { get; set; }
        public List<ObjectSubobjects> list { get; set; }
    }
    public class ObjectSubobjects
    {
        public string variableName { get; set; }
        public Guid id { get; set; }
        public int AIRSTATIONChannel { get; set; }
    }
