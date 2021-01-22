    public interface IModel
    {
        GatewayBase Gateway { get; }
    }
    public abstract class ModelBase<TGateway> : IModel
        where T : GatewayBase
    {
        public ModelBase(TGateway gateway)
        {
            this.Gateway = gateway;
        }
        public TGateway Gateway { get; private set; }
        GatewayBase IModel.Gateway { get { return this.Gateway; } }
    }
    public class Model : ModelBase<Gateway>
    {
        public Model(Gateway gateway)
            : base(gateway)
        {
        }
    }
