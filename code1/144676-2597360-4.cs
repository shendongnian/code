    public class GameObjectController /* ... */
    {
        /* ... */
        public GameObjectController()
        {
            Model = new GameObjectModel(this);
        }
        public GameObjectModel Model { get; protected set; }
    }
    public class CombatantGameObject : GameObjectController
    {
        /* ... */
        public CombatantGameObject()
        {
            Model = new CombatantModel(this);
        }
    }
    /* ... */
