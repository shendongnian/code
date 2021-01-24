    public class Tasks
            {
                public int Id;
                public string Action;
                public int Source;
                public int Target;
            }
    
            static void Main(string[] args)
            {
                List<Tasks> tasks = new List<Tasks>{
                                        new Tasks{Id=1,Action="Save",Source= 12,Target=18},
                                        new Tasks{Id=4,Action="Save",Source= 18,Target=21},
                                        new Tasks{Id=7,Action="Save",Source= 21,Target=23},
                                        new Tasks{Id=6,Action="Save",Source= 23,Target=25},
                                        new Tasks{Id=10,Action="Save",Source= 25,Target=27},
                                        new Tasks{Id=16,Action="Save",Source= 29,Target=31},
                                        new Tasks{Id=0,Action="Edit",Source= 31,Target=37},
                };
                var collectTasks = (from t in tasks
                                    where !tasks.Any(t1 => (t1.Target == t.Source)&&(t1.Action == t.Action)&&(t1.Id!=t.Id))
                                    select t).ToList();
                         
                foreach (var ct in collectTasks)
                {
                    do{
                        var t1 = from t in tasks where ((ct.Target == t.Source)&&(ct.Action == t.Action)&&(ct.Id!=t.Id)) select t;
                        if (t1.Count() == 0) { break; }
      
                        ct.Target = t1.First().Target;
                     } while (true);
                }
            foreach (var t in collectTasks)
            {
                Console.WriteLine("Action = {0}, Source = {1}, Target = {2}", t.Action, t.Source, t.Target);
            }
    
         }
