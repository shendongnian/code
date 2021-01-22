    class Task
    {
        private TaskDetail m_Detail;
        public TaskDetail Detail { get { return m_Detail; } }
    }
    abstract class TaskDetail { ... }
    class PhoneCallDetail : TaskDetail { ... }
    class FaxDetail : TaskDetail { ... }
    class EmailDetail : TaskDetail { ... }
