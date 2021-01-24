C#
public Task StartAsync(CancellationToken cancellationToken)
{
    _myServiceFromLibrary.RunTasks();
    return Task.CompletedTask;
}
public ICollection<IProgress<int>> RunTasks()
{
    var taskList1 = new List<ITask> { Task1, Task2 };
    var plist1 = taskList1.Select(t => t.Progress).ToList();
    var taskList2 = new List<ITask> { Task3, Task4, Task5 }:
    var plist2 = taskList2.Select(t => t.Progress).ToList();
    taskList1.foreach( task => task.Run() );
    Parallel.Foreach(taskList2, task => { task.Run() });
    return plist1.Concat(plist2).ToList();
}
`Task.Progress` there is probably a progress getter. realistically IProgress<T> should probably be injected via Tasks constructors. But the point is your public interface doesn't accept list of tasks, thus it should just return collection of progress reports.
How to inject progress reporters into your tasks is a different story that depends on tasks implementations and it may or may not be supported. out of the box.
