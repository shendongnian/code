    public class Evaluation
    {
        public virtual void Save()
        {
            // Save the common information.
        }
    }
    
    public class EvaluationType1 : Evaluation
    {
        public override void Save()
        {
            // Save the common information.
            base.Save();
    
            // Save the specific information here.
        }
    }
