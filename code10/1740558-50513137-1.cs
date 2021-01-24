    public interface IMyService : IDisposable {
        Task<int> Create(MyEntity model);
    }
    public sealed class MyService : IMyService {
        MyDb db = new MyDb();
        private readonly IAuditor auditor;
    
        public MyService(IAuditor auditor) {
            this.auditor = auditor;
        }
    
        public async Task<int> Create(MyEntity model) {
            auditor.Stamp(model);
            db.MyEntities.Add(model);
            return await db.SaveAsync();
        }
    
        public void Dispose() {
            db.Dispose();
        }
    }
