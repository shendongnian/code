        public class Employee
        {
            public string EmployeeName;
            public string EmployeeID;
        }
        public class Task
        {
            public string TaskName;
            public List<Employee> EmployeeList = new List<Employee>();
        }
        public void TestTaskList()
        {
            // list of tasks.
            List<Task> m_TaskList = new List<Task>();
            // create a new task.
            Task oFirstTask = new Task { TaskName = "First Task" };
            // add this task to your list
            m_TaskList.Add(oFirstTask);
            // loop through your tasks.
            foreach( Task oTask in m_TaskList) {
                if (oTask.EmployeeList.Count() == 0) 
                    // there are no employees, so add one
                    oTask.EmployeeList.Add(
                        new Employee { EmployeeName = "mschietinger" }
                        );
            }
        }
