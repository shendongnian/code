    using System.Collections.Generic;
    public abstract class IAM
    {
        int ID { get; set; }
        internal abstract void Save();
    }
    public class concreteIAM : IAM
    {
        public int ID { get; set; }
        internal override void Save()
        {
            //save the object
        }
        //other staff for this particular class
    }
    public class MyList : List<IAM>
    {
         internal void Save()
        {
            foreach (IAM iam in this)
            {
                iam.Save();
            }
        }
        //other staff for this particular class
    }
