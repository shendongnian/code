    public static class EnumUtility {
        #region --Database Readers Enum
        public static class EnumDBReader {
             public enum Actions { Create, Retrieve, Update, Delete}; 
        }
        #endregion
        #region --Database Users Enum
        public static class EnumDBUsers {
             public enum UserIdentity { user, admin }; 
        }
        #endregion
    }
