    class SR
    {
        public int SRNumber { get; set; }
        public string Tasks { get; set; }
        public bool Status { get; set; }
    }
    
    ...
    
    var list = new List<SR>
    {
        new SR { SRNumber = 1, Tasks = "Foo", Status = true },
        new SR { SRNumber = 2, Tasks = "Bar", Status = false },
        ...
    };
    
    dataGridView.DataSource = list;
