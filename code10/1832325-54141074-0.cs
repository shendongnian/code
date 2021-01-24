    private static object _sync = new object();
    
    ...
    
    private static void TaskFunc(List<ExampleClass> intlist, List<ExampleClass> anotherClassList, int skip, int take)
    {
    
       ...
    
       var partial = intlist.Skip(skip).Take(take).ToList();
       ...
    
       lock (_sync)
       {
          for (var index = 0; index < partial.Count; ++index)
          {
             // this is your problem, you are adding to a list from multiple threads
             anotherClassList.Add(...);
          }
       }
    
    }
