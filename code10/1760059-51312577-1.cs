    public static class PRRoles {
        public static Dictionary<int, string> Roles {
            get {
                return DAPRRoles.GetPRRoles();
            }
        }
        public static bool IsPRRole(int i){
            return Roles.ContainsKey(i);
        }
    }
    public class DAPRRoles {
        public static Dictionary<int, string> GetPRRoles() {
            Dictionary<int, string> dicRoles = new Dictionary<int, string>();
            dicRoles.Add(1, "One");
            dicRoles.Add(5, "five");
            return dicRoles;
        }
    }
    public enum RoleType {
        Undefined = 0,
        Employee = 1,
        JobManager = 2,
        Delegate = 3,
        JobManager2 = 4,
    }
