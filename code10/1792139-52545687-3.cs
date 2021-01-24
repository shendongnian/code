    class User : ISecretUser {
        int id {get; set;}
        bool accessGranted {get; set;}
        string secretInfo {
          get {
                if (accessGranted)
                  return _secretInfo;
                else
                  return null;
              }
          set {
                if (accessGranted)
                  _secretInfo = value;
              }
        }
        string _secretInfo;
        string publicInfo {get; set;}
    }
