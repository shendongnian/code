    class ModelA {
        public ModelA()
        {
            TaskList = new Collection<ModelB>();
        }
        public int ID { get; set; }
        public string PersonName { get; set;}
        ICollection<ModelB> TaskList { get; set; }
    }
