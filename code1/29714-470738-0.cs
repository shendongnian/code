    public class DecoratedModel : Model
    {
        public DecoratedModel(Model baseModel)
            : base(baseModel)
        {
            // Populate decorated model generically from baseModel
        }
    }
    public class Model
    {
        public Model(Model copy)
        {
            this.x = copy.x;
            // etc.
        }
    }
