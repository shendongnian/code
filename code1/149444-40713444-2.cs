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
		private bool _isPaused;
		public bool IsPaused
		{
			get { return _isPaused; }
			set
			{
				_isPaused = value;
				if (_isPaused)
				{
					_triggerTimer.Enabled = false;
				}
				else
				{
					_triggerTimer.Enabled = true;
				}
			}
		}
		public Scheduler()
		{
			_triggerTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
			_triggerTimer.Enabled = true;
			_triggerTimer.Interval = 1000;
		}
		private void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			var now = DateTime.Now;
			var jobs = _jobs;
			var tasksNeedToRun = jobs.Where(a => 
				a.Execution.Hour == now.Hour 
				&& a.Execution.Minute == now.Minute 
				&& a.Execution.Second == now.Second
				).ToArray();
			if (tasksNeedToRun.Count() > 0)
			{
				foreach (var job in tasksNeedToRun)
				{
					switch (job.RunType)
					{
						case RunType.OneTimeRun:
							if (now.Year == job.Execution.Year &&
							now.Month == job.Execution.Month &&
							now.Day == job.Execution.Day)
							{
								job.Task.Start();
								_jobs.Remove(job);
								Console.WriteLine($"Job '{job.Name}' was runned at {DateTime.Now} (and must be runned at {job.Execution} )");
							}
							break;
						case RunType.EveryDay:
								job.Task.Start();
								_jobs.Remove(job);
								Console.WriteLine($"Job '{job.Name}' was runned at {DateTime.Now.ToString("hh:mm:ss")} (and must be runned at {job.Execution.ToString("hh:mm:ss")} )");
							break;
						default:
							throw new Exception("Unknown Run type");
					}
					
				}
			}
		}
		public void Add(string name, RunType runType, DateTime execution, Action lambda)
		{
			var itemsFound = _jobs.Where(item => item.Name == name).ToArray();
			if (itemsFound.Count() > 0)
			{
				throw new Exception("Task name is not unique");
				return;
			}
			_jobs.Add(new Job() { Name = name, Execution = execution, Task = new Task(lambda), RunType = runType });
			Console.WriteLine($"Added  {runType} schedule on : {execution}");
		}
		//TODO: FUKS 
		public void AddRunEvery(string name, RunType runType, DateTime startFrom, DateTime executionEvery, int randomizationInSeconds, Action lambda)
		{
			_triggerTimer.Enabled = false;
			DateTime currSchedule = startFrom;
			DateTime finishTime = startFrom.AddDays(1);
			DateTime executionEveryRandom = executionEvery;
			DateTime currScheduleTmp;
			int rndMinsInSec = randomizationInSeconds / 60;
			int rndSec = randomizationInSeconds % 60;
			
			if (executionEvery.Hour > 0 || executionEvery.Minute > rndMinsInSec)
			{
				Random rndForMin = new Random();
				int rndMin = rndForMin.Next(-rndMinsInSec, rndMinsInSec);
				executionEveryRandom = executionEveryRandom.AddMinutes(rndMin);
			}
			if (executionEvery.Minute > 0 || executionEvery.Second > rndSec)
			{
				Random rndForSec = new Random();
				int rndSeconds = rndForSec.Next(-rndSec, rndSec);
				executionEveryRandom = executionEveryRandom.AddMinutes(rndSeconds);
			}
			int i = 0;
			while (currSchedule < finishTime)
			{
				currScheduleTmp = currSchedule;
				currSchedule = currSchedule
					.AddHours(executionEvery.Hour)
					.AddMinutes(executionEvery.Minute)
					.AddSeconds(executionEvery.Second);
				
				currScheduleTmp = currScheduleTmp
					.AddHours(executionEveryRandom.Hour)
					.AddMinutes(executionEveryRandom.Minute)
					.AddSeconds(executionEveryRandom.Second);
				i++;
				
				Add(name + i, runType, currScheduleTmp, lambda);
			}
			Console.WriteLine($"Was added {i} jobs");
			_triggerTimer.Enabled = true;
		}
		public void AddRunEvery(string name, RunType runType, DateTime startFrom, DateTime executionEvery, Action lambda)
		{
			AddRunEvery(name, runType, startFrom, executionEvery, 0, lambda);
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
