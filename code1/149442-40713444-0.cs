	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Threading.Tasks;
	using System.Timers;
	public class Scheduler
	{
		private Timer _triggerTimer = new Timer();
		private List<Job> _jobs = new List<Job>();
		public ReadOnlyCollection<Job> Jobs { get { return new ReadOnlyCollection<Job>(_jobs); } }
		public Scheduler()
		{
			_triggerTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
			_triggerTimer.Enabled = true;
			_triggerTimer.Interval = 1000;
		}
		private void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			var now = DateTime.Now;
			var tasksNeedToRun = _jobs.Where(a => 
				a.Execution.Hour == now.Hour 
				&& a.Execution.Minute == now.Minute 
				&& a.Execution.Second == now.Second
				).ToArray();
			if (tasksNeedToRun.Count() > 0)
			{
				foreach (var job in tasksNeedToRun)
				{
					if (job.RunType == RunType.OneTimeRun)
					{
						if (now.Year == job.Execution.Year &&
							now.Month == job.Execution.Month &&
							now.Day == job.Execution.Day)
						job.Task.Start();
						Console.WriteLine($"Job '{job.Name}' was runned at {DateTime.Now} (and must be runned at {job.Execution} )");
						break;
					}
					else if (job.RunType == RunType.EveryDay)
					{
						job.Task.Start();
						Console.WriteLine($"Job '{job.Name}' was runned at {DateTime.Now.ToString("hh:mm:ss")} (and must be runned at {job.Execution.ToString("hh:mm:ss")} )");
					}
				}
			}
		}
		public void Add(string name, RunType runType, DateTime execution, Task task)
		{
			var itemsFound = _jobs.Where(item => item.Name == name).ToArray();
			if (itemsFound.Count() > 0)
			{
				throw new Exception("Task name is not unique");
				return;
			}
			_jobs.Add(new Job() { Name = name, Execution = execution, Task = task, RunType = runType });
		}
		public void Remove(string name)
		{
			var itemsFound = _jobs.Where(item => item.Name == name).ToArray();
			if (itemsFound.Count() > 0)
			{
				_jobs.Remove(itemsFound[0]);
				return;
			}
			throw new Exception("Job not found");
		}
		public void Clean()
		{
			_jobs = new List<Job>();
		}
	}
	public class Job : EventArgs
	{
		public string Name;
		public Task Task;
		public DateTime Execution;
		public RunType RunType = RunType.EveryDay;
	}
	public enum RunType
	{
		OneTimeRun,
		EveryDay
	}
