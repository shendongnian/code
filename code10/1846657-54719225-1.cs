C#
public Task<ICollection<IProgress<int>>> StartAsync(CancellationToken cancellationToken)
{
    var progressList = _myServiceFromLibrary.RunTasks();
    return Task.FromResult(progressList);
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
However what you probably should do is to supply progress callback or progress factory so that progress reporters of your choice are created:
C#
public Task StartAsync(CancellationToken cancellationToken, Action<Task,int> onprogress)
{
    _myServiceFromLibrary.RunTasks(onprogress);
    return Task.CompletedTask;
}
public class SimpleProgress : IProgress<int>
{
    private readonly Task task;
    private readonly Action<Task,int> action;
    public SimpleProgress(Task task, Action<Task,int> action)
    {
        this.task = task;
        this.action = action;
    }
    public void Report(int progress)
    {
        action(task, progress);
    }
}
public ICollection<IProgress<int>> RunTasks(Action<Task,int> onprogress)
{
    var taskList1 = new List<ITask> { Task1, Task2 };
    taskList1.foreach(t => t.Progress = new SimpleProgress(t, onprogress));
    var taskList2 = new List<ITask> { Task3, Task4, Task5 }:
    taskList2.foreach(t => t.Progress = new SimpleProgress(t, onprogress));
    taskList1.foreach( task => task.Run() );
    Parallel.Foreach(taskList2, task => { task.Run() });
}
you may see here, that it really is mostly question about how your tasks are going to call `IProgress<T>.Report(T value)` method.
