    public abstract class BaseRule
        {
            public virtual bool IsValidMove(object moveDescription);
        }
    
        public class Round1Rule : BaseRule
        {
            public override bool IsValidMove(object moveDescription)
            {
                return true;
            }
        }
    
        public class Round2Rule : BaseRule
        {
            public override bool IsValidMove(object moveDescription)
            {
                return false;
            }
        }
