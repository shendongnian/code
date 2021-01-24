    // Anything you want to track in the game
    public interface IGameEntity {}
    // Anything that opposes a plyaer
    public interface IEnemy : IGameObject {}
    // Anything used to do Physical Harm
    public interface IWeapon : IGameObject {}
    // Anything that can be collected for a purpose (wood, gold, etc)
    public interface IResource : IGameObject {}
