    public void DeleteTask(Task task)
        {
            TwoDooDataContext db = new TwoDooDataContext();
            db.Tasks.Attach(task,GetTaskByID(task.ID));
            db.Tasks.DeleteOnSubmit(task);
            db.SubmitChanges();
        }
