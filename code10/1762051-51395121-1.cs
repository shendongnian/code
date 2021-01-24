    public interface UnitOfWorkFactory {
	    AccountsMstRepository AccountsMstRepository {get; set;}
        ErpOneLogRepository ErpOneLogRepository get; set;}
        DeleteRecordRepository DeleteRecordRepository {get; set;}
	    DbContext DbContext {get; set;}
	
	    // CRUD methods to update repository
    }
    public interface RepositoryFactory {
	    DbContext context {get; set;}
	
	    // CRUD methods to update repository
    }
