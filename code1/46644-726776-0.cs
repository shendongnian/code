        abstract class GenericGameObject
        {
            public DefaultGameObjectModel Model
            {
                get { return ModelInternal; }
            }
            protected abstract DefaultGameObjectModel ModelInternal { get; }
        }
        class Missile : GenericGameObject
        {
            private MissileModel model;
             
            public override DefaultGameObjectModel ModelInternal
            {
                get { return model; }
            }
            public new MissileModel Model
            {
                get { return model; }
                set { model = value; }
            }
        }
    class DefaultGameObjectModel { public Vector2 Position = new Vector2(){X=0}; }
    class MissileModel : DefaultGameObjectModel { }
    
    Missile m = new Missile();
    m.Model.Position.X = 10;
