    public abstract class ModelBase
    {
        public ModelBase(GatewayBase gateway)
        {
            this.Gateway = gateway;
        }
        public GatewayBase Gateway { get; private set; }
    }
    public class Model : ModelBase
    {
        public Model(Gateway gateway)
            : base(gateway)
        {
        }
        public new Gateway { get { return (Gateway) base.Gateway; } }
    }
