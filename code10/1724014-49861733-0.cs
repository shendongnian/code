    public interface IPlayer {
        // method 1
        int Attack(int amount);
    }
    public interface IPowerPlayer : IPlayer {
        // no methods, only provides implementation
    }
    public interface ILimitedPlayer : IPlayer {
        // method 2, in question also provides implementation
        new int Attack(int amount);
    }
