	using System;
	using System.Collections.Generic;
	using System.Data.OleDb;
	using System.IO;
	using System.Linq;
	using Linq2Access.Data;
	namespace Linq2Access
	{
		class Program
		{
			static readonly string AppPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
			static readonly string DbPath = Path.Combine(AppPath, "Data", "database.accdb");
			static readonly string DbConnString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + DbPath + "';Persist Security Info=False;";
			static void Main(string[] args)
			{
				if (!File.Exists(DbPath))
					throw new Exception("Database file does not exist!");
				using (OleDbConnection connection = new OleDbConnection(DbConnString))
				using (DataRepositoryDataContext db = new DataRepositoryDataContext(connection))
				{
					List<dbProject> projects = new List<dbProject>();
					for (int i = 1; i <= 10; i++)
					{
						dbProject p = new dbProject() { Title = "Project #" + i };
						for (int j = 1; j <= 10; j++)
						{
							dbTask t = new dbTask() { Title = "Task #" + (i * j) };
							p.dbTasks.Add(t);
						}
						projects.Add(p);
					}
					try
					{
						//This will fail to submit
						db.dbProjects.InsertAllOnSubmit(projects);
						db.SubmitChanges();
						Console.WriteLine("Write succeeded! {0} projects, {1} tasks inserted",
											projects.Count,
											projects.Sum(x => x.dbTasks.Count));
					}
					catch(Exception ex)
					{
						Console.WriteLine("Write FAILED. Details:");
						Console.WriteLine(ex);
						Console.WriteLine();
					}
					try
					{
						//However, if you create the items manually in Access they seem to query fine
						var projectsFromDb = db.dbProjects.Where(x => x.Title.Contains("#1"))
															.OrderBy(x => x.ProjectID)
															.ToList();
						Console.WriteLine("Query succeeded! {0} Projects, {1} Tasks",
											projectsFromDb.Count,
											projectsFromDb.Sum(x => x.dbTasks.Count));
					}
					catch (Exception ex)
					{
						Console.WriteLine("Query FAILED. Details:");
						Console.WriteLine(ex);
						Console.WriteLine();
					}
					Console.WriteLine();
					Console.WriteLine("Press any key to continue...");
					Console.ReadKey();
				}
			}
		}
	}
