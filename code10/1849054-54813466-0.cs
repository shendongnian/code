    int Sender = 1;
    TestClass test = new TestClass();
    test.AddRange(new []
    {
        new TestClass() { Status = 0, QueueName = "Queue1", SSDocumentID = 1 },
        new TestClass() { Status = 1, QueueName = "Queue1", SSDocumentID = 1 },
        new TestClass() { Status = 1, QueueName = "Queue2", SSDocumentID = 2 },
        new TestClass() { Status = 0, QueueName = "Queue3", SSDocumentID = 3 },
        new TestClass() { Status = 1, QueueName = "Queue4", SSDocumentID = 4 },
    });
    listBox1.DisplayMember = "DisplayMember";
    listBox1.DataSource = test.Filter(Sender);
    public class TestClass
    {
        public TestClass() => this.Members = new List<TestClass>();
        public int Status { get; set; }
        public int SSDocumentID { get; set; }
        public string QueueName { get; set; }
        public string DisplayMember => 
            $"{this.SSDocumentID} | {this.QueueName}";
        public List<TestClass> Members { get; }
        public void Add(TestClass element) => this.Members.Add(element);
        public void AddRange(IEnumerable<TestClass> elements) => this.Members.AddRange(elements.ToArray());
        public IEnumerable<TestClass> Filter(int status)
        {
            if (this.Members.Count == 0) return null;
            return this.Members.Where(st => st.Status == status).ToList();
        }
    }
