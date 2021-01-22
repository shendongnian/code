    public interface IInterface
    {
        object Id { get; }
    }
    public class Simple : IInterface
    {
        private int something;
        public object Id
        {
            get { return something; }
            set{ something = (int)value;}
        }
    }
