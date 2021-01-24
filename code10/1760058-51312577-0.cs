    public static class PRRoles {
        public static Dictionary<int, string> Roles {
            get {
                return null;
            }
        }
        public static bool IsPRRole(int i){
            return Roles.ContainsKey(i);
        }
    }
