    interface IPublicUser {
        int id {get; set;}
        string publicInfo {get; set;}
    }
    
    interface ISecretUser : IPublicUser {
        string secretInfo {get; set;}
    }
    class User : ISecretUser {
        int id {get; set;}
        string secretInfo {get; set;}
        string publicInfo {get; set;}
    }
