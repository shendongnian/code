    public class PermissionDataBase : MyContext<Permission,int>{  
        //Mapped class Permission where the key is int
        private DbEntities db=null;
        public PermissionDataBase(DbEntities db):base(db) {
            this.db = db;
        }
        //Additional methods (if required)
        public Permission FindByName(string name) {
            return db.Permissions.FirstOrDefault(p => p.Name == name);
        }
        
        public override void Dispose() {
            db.Dispose();
        }
    }
