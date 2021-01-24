    public class SingletonBehaviour<T> where T : new()
    {    
        public static T Instance 
        { 
            get 
            {
                if(instance == null)
                    instance = new T()
                return instance; 
            } 
        } 
        private static T instance { get; set; } 
    }
    public class APIManager // This class should not inherit from the SingletonBehavior class
    {
        // Methods like SendHTTPPost(), HTTPGet(), etc.
    }
    public class ProjectAAPIManager : APIManager 
    {
        public ProjectAAPIManager GetInstance() => SingletonBehavior<ProjectAAPIManager>.Instance();
    }
