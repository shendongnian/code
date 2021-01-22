    public class Project{
    
    public string Title {get;set;}
    public string DevUrl {get;set;}
    public string QAUrl {get;set;}
    public string LiveUrl {get;set;}
    public IEnumerable<User> Users {get;set;}
    
    public static IEnumerable<Project> RetrieveAllProjects()
    {
      return from p in db.Projects
               orderby p.title
               select new Project
                 {
                    Title = p.title,
                    DevURL = p.devURL ?? "N/A",
                    QAURL = p.qaURL ?? "N/A",
                    LiveURL = p.liveURL ?? "N/A",
                    Users = p.GetUsers().MakeUserList()
                 };
    }
