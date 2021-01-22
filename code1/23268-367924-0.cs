    public abstract class IAM
    {
        public abstract int ID { get; set; }
        protected abstract void Save();
    
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
