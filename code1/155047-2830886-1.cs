    public class Database
    {
        // Your stuff
    
        private bool clean = false;
    
        public void Commit()
        {
            this.clean = true;
        }
    
        public void Dispose()
        {
            if (this.clean == true)
                CommitToDatabase();
            else
                Rollback();
        }
    }
