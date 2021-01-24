    public class Task
    {
        //protected task name that can only be set in base or derived classes
        protected string name;
    
        //Property to return task name
        public string Name { get { return name; } }
    
        public Task() {
            
        }
    
        //Task contructor that requires a name value to be instantiated
        public Task(string name)
        {
            this.name = name;
        }
    }
    
    public class DerivedTask1 : Task
    {
        public static const string TASK_NAME = "Derived Task Name 1";
    
        public DerivedTask1() 
        {
            this.name = TASK_NAME;
        }
    }
    
    public class TaskTracker
    { 
        //Private dictionary to hold tasks
        private Dictionary<string, Task> tasks;
    
        public TaskTracker()
        {
            this.tasks = new Dictionary<string, Task>();
        }
    
        public void AddTask(Task task) {
            //Adds a task to the dictionary, note that there is no error checking and will fail when task with duplicate name is added
            this.tasks.Add(task.Name, task);
        }
    
        public void AddTasks(List<Task> newTasks)
        {
            //Adds all tasks in a list to the backing task dictionary
            foreach(Task task in newTasks)
            {
                AddTask(task);
            }
        }
    
        public Task GetTask(string taskName)
        {
            if (this.tasks.ContainsKey(taskName))
            {
                return this.tasks[taskName];
            }
            else
            {
                return null;
            }
        }
    }
