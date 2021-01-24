    List<Task> tasks = (The list of tasks I want to save);
    MainJob job = db.Jobs.SingleOrDefault(j => j.jobId == jobId);
    job.task = tasks;
    foreach (var task in tasks)
    {
        if(task.contractId != 0) // New task
        {
            db.Tasks.Attach(task);
            db.Entry(task).State = EntityState.Modified; // If modified
            // otherwise can set it to Unchanged
            // db.Entry(task).State = EntityState.Unchanged;
        }
    }
    db.SaveChanges();
