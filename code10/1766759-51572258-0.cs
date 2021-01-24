    namespace ConsoleApp1
    {
        class PrintDetails
        {
            public void Print(List<TaskDetails> taskDetails, int i)
            {
                var taskDetail = taskDetails[i];
    
                Console.WriteLine(string.Format(
                    "UserID: {0}, TaskTitle: {1}",
                    taskDetail.UserID,
                    taskDetail.TaskTitle);
            }
        }
    }
