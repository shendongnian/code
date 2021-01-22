    interface IGameObjectController
    {
        // Interface here.
    }
    interface ICombatant : IGameObjectController
    {
        // Interface for combat stuff here.
    }
    class GameObjectController : IGameObjectController
    {
        // Implementation here.
    }
    class FooActor : GameObjectController, ICombatant
    {
        // Implementation for fighting here.   
    }
