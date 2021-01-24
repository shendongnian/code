    public static class UpdateExceptionHelper
    {
        public enum UpdateExceptionKind
        {
            UniqueViolation,
            ForeignKeyViolation,
            Unknown
        }
        
        public static UpdateExceptionKind Kind(this DbUpdateException dbUpdateException)
        {
            var inner = dbUpdateException.InnerException;
            switch (inner)
            {
                case null:
                    return UpdateExceptionKind.Unknown;
                case SqliteException sqlite:
                    return sqlite.Kind();
                case PostgresException postgres:
                    return postgres.Kind();
                default:
                    throw new Exception($"Unsupported Database Provider with Exception Type: {inner.GetType().Name}");
                    
                
            }
        }
        
        private static UpdateExceptionKind Kind(this PostgresException e)
        {
            const string UNIQUE_VIOLATION = "23505";
            const  string FOREIGN_KEY_VIOLATION = "23503";
            
            switch (e.SqlState)
            {
                case UNIQUE_VIOLATION:
                    return UpdateExceptionKind.UniqueViolation;
                case FOREIGN_KEY_VIOLATION:
                    return UpdateExceptionKind.ForeignKeyViolation;
                default:
                    return UpdateExceptionKind.Unknown;
            }
        }
        private static UpdateExceptionKind Kind(this SqliteException e)
        {
            const int SQLITE_CONSTRAINT_UNIQUE = 2067;
            const int SQLITE_CONSTRAINT_PRIMARYKEY = 1555;
            const int SQLITE_CONSTRAINT_FOREIGNKEY = 787;
            
            switch (e.SqliteExtendedErrorCode)
            {
                case SQLITE_CONSTRAINT_PRIMARYKEY:
                case SQLITE_CONSTRAINT_UNIQUE:
                    return UpdateExceptionKind.UniqueViolation;
                case SQLITE_CONSTRAINT_FOREIGNKEY:
                    return UpdateExceptionKind.ForeignKeyViolation;
                default:
                    return UpdateExceptionKind.Unknown;
            }
        }
    }
 
