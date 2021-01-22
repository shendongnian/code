    public interface IAM
    {
            int ID { get; set; }
    }
    internal interface IAMSavable
    {
            void Save();
    }
    public class concreteIAM : IAM, IAMSavable
    {
             public int ID{get;set;}
             public void IAMSavable.Save(){
             //save the object
             }
            //other staff for this particular class
    }
    public class MyList : List<IAM>
    {
            public void Save()
            {
                    foreach (IAM iam in this)
                    {
                            ((IAMSavable)iam).Save();
                    }
            }
            //other staff for this particular class
    }
