    public class TaskFactory
    {
        private Dictionary<String, Type> _taskTypes = new Dictionary<String, Type>();
        public TaskFactory()
        {
            // Preload the Task Types into a dictionary so we can look them up later
            foreach (Type type in typeof(TaskFactory).Assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(CCTask)))
                {
                    _taskTypes[type.Name.ToLower()] = type;
                }
            }
        }
        public CCTask CreateTask(XmlElement task)
        {
            if (task != null)
            {
                string taskName = task.Name;
                taskName =  taskName.ToLower() + "task";
                // If the Type information is in our Dictionary, instantiate a new instance of that task
                Type taskType;
                if (_taskTypes.TryGetValue(taskName, out taskType))
                {
                    return (CCTask)Activator.CreateInstance(taskType, task);
                }
                else
                {
                    throw new ArgumentException("Unrecognized Task:" + task.Name);
                }                               
            }
            else
            {
                return null;
            }
        }
    }
