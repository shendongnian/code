    using Windows.Foundation;
    public struct LevellableChange {
        public LevellableChange( int dl, int dxp) 
        { 
             this.ChangeInLevel = dl;
             this.ChangeInXP = dxp;
        }
        int ChangeInLevel { get; }
        int ChangeInXP {get;}
    }
    public interface ILevellable
    {
        int Level { get; }
        int MaxLevel { get; }
        int XP { get; }
        event TypedEventHandler< ILevellable, LevellableChange> Changed;
    }
