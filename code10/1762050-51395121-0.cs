    public interface IController {
        HttpContext Context{get; set; }
        string Username {get; set; }
        IHostingEnvironment Environment {get; set; }
        string User {get; set; }
        string DbName {get; set; }
        UnitOfWork ControllerWork {get; set;}
    }
