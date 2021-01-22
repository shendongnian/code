    public class MotorRenewalRepository : IMotorRenewalRepository
    {
        MyDataContext _dataContext = new MyDataContext();
        public void Add(MotorRenewal motorRenewal)
        {
            _dataContext.MotorRenewals.InsertOnSubmit(motorRenewal);
        }
        public void Delete(MotorRenewal motorRenewal)
        {
            _dataContext.MotorRenewals.DeleteOnSubmit(motorRenewal);
        }
        public void Save()
        {
            _dataContext.SubmitChanges();
        }
        public IQueryable<MotorRenewal> FindAll()
        {
            return _dataContext.MotorRenewals.AsQueryable();
        }
        public User FindMotorRenewalById(int id)
        {
            return _dataContext.MotorRenewals.Where(p => p.MotorRenewalDataID == id).SingleOrDefault();
        }
    }
