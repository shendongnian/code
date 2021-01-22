    public class UserRepository : IUserRepository
    {
        private IDatabase db;
        public UserRepository(IDatabase db)
        {
            if (db == null)
            {
                throw new ArgumentNullException("db");
            }
            this.db = db;
        }
        public void SaveUser(User user)
        {
            int userID = user.ID;
            DateTime createDate = user.CreatedOn;
            DateTime updateDate = DateTime.Now;
            long phoneNumber = PhoneNumberConverter.Parse(user.PhoneNumber);
            using (TransactionScope tsc = new TransactionScope())
            {
                if (user.ID == 0)
                {
                    createDate = updateDate;
                    userID = db.InsertUser(user.Name, phoneNumber, createDate,
                        updateDate);
                }
                else
                {
                    db.UpdateUser(user.ID, user.Name, phoneNumber, updateDate);
                }
                tsc.Complete();
            }
            user.ID = userID;
            user.CreatedOn = createDate;
            user.LastModified = updateDate;
        }
    }
