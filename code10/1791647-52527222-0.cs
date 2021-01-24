	using System;
	using System.Collections.Generic;
	using System.Linq;
	public class Program
	{
		public static void Main()
		{
			var projectList = new List<Project>
			{
				new Project{Name = "Object 1", BeginDate = new DateTime(2017,12,21), EndDate = new DateTime(2018,01,20)},
				new Project{Name = "Object 2", BeginDate = new DateTime(2017,12,01), EndDate = new DateTime(2017,12,21)},
				new Project{Name = "Object 3", BeginDate = new DateTime(2017,10,25), EndDate = new DateTime(2017,12,01)},
				new Project{Name = "Object 4", BeginDate = new DateTime(2017,09,17), EndDate = new DateTime(2017,10,25)},
				new Project{Name = "Object 5", BeginDate = new DateTime(2017,08,01), EndDate = new DateTime(2017,09,02)},
				new Project{Name = "Object 6", BeginDate = new DateTime(2017,06,25), EndDate = new DateTime(2017,07,26)},
				new Project{Name = "Object 7", BeginDate = new DateTime(2017,04,20), EndDate = new DateTime(2017,06,25)},
			};
			var newList = new List<Project>();
			while(projectList.Count > 0)
			{
				var item = projectList.ElementAt(0);
				projectList.Remove(item);
				newList.Add(item);
				//Console.WriteLine(item);
				var match = Match(item, projectList);
				while (match != null)
				{
					//Console.WriteLine("match: " + match.ToString());
					projectList.Remove(match);
					item.BeginDate = item.BeginDate < match.BeginDate ? item.BeginDate : match.BeginDate;
					item.EndDate = item.EndDate > match.EndDate ? item.EndDate : match.EndDate;
					item.IsLongTerm = true;
					//Console.WriteLine("adjusted: " + item.ToString());
					match = Match(item, projectList);
				}
			}
			foreach(var project in newList)
			{
				Console.WriteLine(project.ToString());
			}
		}
		private static Project Match(Project project, IEnumerable<Project> projects)
		{
			var result = projects.FirstOrDefault(p => 
				(project.BeginDate.AddDays(-1) < p.BeginDate && p.BeginDate < project.EndDate.AddDays(1) )
				|| (project.BeginDate.AddDays(-1) < p.EndDate && p.EndDate < project.EndDate.AddDays(1)) );
			return result;
		}
	}
	public class Project
	{
		public string Name { get; set; }
		public DateTime BeginDate { get; set; }
		public DateTime EndDate { get; set; }
		public bool IsLongTerm { get; set; }
		public override string ToString()
		{
			return Name + " " + BeginDate.ToString("yyyy-MM-dd") + " " + EndDate.ToString("yyyy-MM-dd");
		}
	}
	
