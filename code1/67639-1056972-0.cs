    public interface IAutoComplete
    {
        DataSet Complete(string filter, long rowOffset);
    }
    public class CustomerAutoComplele : IAutoComplete
    {
        public DataSet Complete(string filter, long rowOffset)
        {
            var c = Connect();
            // some code here
        }
    }
