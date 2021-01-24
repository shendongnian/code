    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var projectList = new List<Project>
    		{
    			new Project{Id = "Object 0", BeginDate = new DateTime(2018,01,20), EndDate = null},
    			new Project{Id = "Object 1", BeginDate = new DateTime(2017,12,21), EndDate = new DateTime(2018,01,20)},
    			new Project{Id = "Object 2", BeginDate = new DateTime(2017,12,01), EndDate = new DateTime(2017,12,21)},
    			new Project{Id = "Object 3", BeginDate = new DateTime(2017,10,25), EndDate = new DateTime(2017,12,01)},
    			new Project{Id = "Object 4", BeginDate = new DateTime(2017,09,17), EndDate = new DateTime(2017,10,25)},
    			new Project{Id = "Object 5", BeginDate = new DateTime(2017,08,01), EndDate = new DateTime(2017,09,02)},
    			new Project{Id = "Object 6", BeginDate = new DateTime(2017,06,25), EndDate = new DateTime(2017,07,26)},
    			new Project{Id = "Object 7", BeginDate = new DateTime(2017,04,20), EndDate = new DateTime(2017,06,25)},
    		};
    		
    		var resultsList = new List<Project>();
    		var previousProject = new Project();
    		var currentProject = new Project();
    		
    		foreach(var p in projectList.OrderBy(p => p.BeginDate))
    		{
    			if (string.IsNullOrEmpty(previousProject.Id))
    			{
    				previousProject = currentProject = p;
    				continue;
    			}
    			
    			if (p.BeginDate.AddDays(-1)<=previousProject.EndDate)
    			{
    				currentProject.EndDate = p.EndDate;
    				previousProject = currentProject;
    				continue;
    			}
    			else
    			{
    				resultsList.Add(currentProject);
    				previousProject = currentProject = p;
    			}
    		}
    		resultsList.Add(currentProject);
    		
    		foreach(var p in resultsList)
    		{
    			var endDate = p.EndDate?.ToString("yyyy-MM-dd");
    			Console.WriteLine("{0}\t{1}\t{2}", p.Id, p.BeginDate.ToString("yyyy-MM-dd"), ((string.IsNullOrEmpty(endDate))?"Null":endDate));
    		}
    	}
    }
    
    public class Project
    {
    	public string Id { get; set; }
    	public DateTime BeginDate { get; set; }
    	public DateTime? EndDate { get; set; }
    }
