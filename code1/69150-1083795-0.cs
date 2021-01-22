    public sealed class WcfClient<T: System.ServiceModel.ClientBase<T>
          where T : class
    {
        public T Service { get { return base.Channel; } }
    }
