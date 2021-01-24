    class Flow
    {
        [NameAttribute("Workflow Name")]
        public string WorkflowName { get; set; }
        [NameAttribute("Workflow Description")]
        public string WorkflowDescription { get; set; }
        public Flow(string workflowName, string workflowDescription)
        {
            WorkflowName = workflowName;
            WorkflowDescription = workflowDescription;
        }
    }
    //...
    var data = from flow in myWorkflows.WorkFlowCollection
               select new Flow(flow.WorkflowName,flow.WorkflowDescription);
    using (var writer = new StreamWriter("test.csv"))
    using (var csv = new CsvWriter(writer))
    {
        csv.WriteRecords(data);
    }
