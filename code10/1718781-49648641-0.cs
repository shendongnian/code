    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication33
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Task> tasks = new List<Task>() {
                    new Task() { Id = 1, Action = "Save", Source = 12, Target = 18},
                    new Task() { Id = 4, Action = "Save", Source = 18, Target = 21},
                    new Task() { Id = 7, Action = "Save", Source = 21, Target = 23},
                    new Task() { Id = 6, Action = "Save", Source = 23, Target = 25},
                    new Task() { Id = 10, Action = "Save", Source = 25, Target = 27},
                    new Task() { Id = 16, Action = "Save", Source = 29, Target = 31},
                    new Task() { Id = 0, Action = "Edit", Source = 31, Target = 37}
                };
                for(int i = tasks.Count - 1; i >= 0; i--)
                {
                    int source = tasks[i].Source;
                    List<int> match = tasks.Select((x, index) => new { x = x, i = index }).Where(x => (x.x.Target == source) && (tasks[i].Action == tasks[x.i].Action)).Select(x => x.i).ToList();
                    if (match.Count > 0)
                    {
                        tasks[match[0]].Target = tasks[i].Target;
                        tasks.RemoveAt(i);
                        
                    }
                }
            }
        }
        public class Task
        {
            public int Id { get; set; }
            public string Action { get; set; }
            public int Source { get; set; }
            public int Target { get; set; }
        }
    }
