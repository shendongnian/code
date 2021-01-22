    public Task CreateTask(XmlElement elem)
    {
        if (elem != null)
        { 
            try
            {
              Assembly a = typeof(Task).Assembly
              string type = string.Format("{0}.{1}Task",typeof(Task).Namespace,elem.Name);
  
              //this is only here, so that if that type doesn't exist, this method
              //throws an exception
              Type t = a.GetType(type, true, true);
              return a.CreateInstance(type, true) as Task;
            }
            catch(System.Exception)
            {
              throw new ArgumentException("Invalid Task");
            }
        }
    }
