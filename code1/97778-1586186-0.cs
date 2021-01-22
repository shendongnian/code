    public TaskTimeLine GetTaskAndTimeLine(int taskId)
    {
       TaskTimeLine taskTimeLine = new TaskTimeLine(); // create new main object
       ...[snip]
       return taskTimeLine;
    }
    ...
    TaskTimeLine task = taskRepository.GetTaskAndTimeLine(id);
