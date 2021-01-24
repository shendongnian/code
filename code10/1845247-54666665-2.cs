    public abstract class AbstractHex
    {
        string MyProperty1 { get; set; }
        ...
        string MyProperty10 { get; set; }
        ...
        TileType TileType { get; }
        protected Hex(AbstractHex hex = null)
        {
           if (hex != null)
           {
              this.MyProperty1 = hex.MyProperty1;
              // etc 
           }
        }
        ...
        Hex specific virtual methods
    }
    public sealed class WaterHex : AbstractHex
    {
        // implements props here
 
        public WaterHex(AbstractHex copyFrom = null) : base(copyFrom)
        {
           TileType = TileTypes.Water;
        }
        ...
        override virtual methods with behavior specific for WaterHex
    }
    public sealed class FireHex : AbstractHex
    {
        // implements props here
 
        public WaterHex(AbstractHex copyFrom = null) : base(copyFrom)
        {
           TileType = TileTypes.Fire;
        }
        ...
        override virtual methods with behavior specific for FireHex
    }
