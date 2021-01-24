        [Route("api/Task")]
        public void Delete(int developerId, int projectId, DateTime workDate)
        {
            var taskModel = new TaskModel
            {
                DeveloperId = developerId,
                ProjectID = projectId,
                WorkDate = workDate
            };
            TaskPersistent tp = new TaskPersistent();
            tp.deleteTask(taskModel);
        }
