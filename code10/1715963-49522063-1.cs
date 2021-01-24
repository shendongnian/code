    public abstract class BaseAction
    {
        protected abstract ChangeID(int value);
        protected virtual void RetrieveData()
        {
            //Do your stuff
            ChangeID(<with-new-value>);
        }
    }
    public class Action: BaseAction
    {
        Protected override ChangeID(int value)
        {
            //Do whatever you want
        }
        public Action()
        {
            ActionStatement(RetrieveData);
        }
    }
