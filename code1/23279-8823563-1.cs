        public interface IAM
        {
                int ID { get; set; }
                void Save();
        }
        public class concreteIAM : IAM
        {
                 public int ID{get;set;}
                 internal void Save(){
                 //save the object
                 }
                //other staff for this particular class
        }
        public class MyList : List<IAM>
        {
                public void Save()
                {
                        foreach (concreteIAM iam in this)
                        {
                                iam.Save();
                        }
                }
                //other staff for this particular class
        }
