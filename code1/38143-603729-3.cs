    public class DataAccess
    {
        public void Save()
        {
            if ( _is_new )
            {
                Insert();
            }
            else if ( _is_modified )
            {
                Update();
            }
        }
    }
