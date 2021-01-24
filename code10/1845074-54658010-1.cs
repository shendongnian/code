    // Class Tasks represents a "table" of Tasks
    class Tasks : IEnumerable<Task>, IEnumerable
    {
        // create at construction. It has the columns of a Task:
        private readonly DataTable dataTable;
        public Tasks()
        {
            // create an empty DataTable
        }
        public Tasks(IEnumerable<Task> tasks)
        {
            // creates a DataTable filled with the tasks
        }
        // only if you sometimes still need the fact that this is internally still a DataTable
        public DataTable DataTable {get;} => this.DataTable;
    }
