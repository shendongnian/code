    public abstract class IAM
    {
        public int ID { get; set; }
        protected virtual void Save()
        {
        }
    
        public class MyList : List<IAM>
        {
            public void Save()
            {
                foreach (IAM iam in this)
                {
                    iam.Save();
                }
            }
        }
    }
