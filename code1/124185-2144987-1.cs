    public interface ICharacter
    {
        //...
        IEnumerable<IAction> Actions { get; }
    }
    public interface IAction
    {
        ICharacter Character { get; }
        void Execute();
    }
    public class BaseAttackBonus : IAction
    {
        public BaseAttackBonus(ICharacter character)
        {
            Character = character;
        }
        public ICharacter Character { get; private set; }   
    
        public void Execute()
        {
            // Get base attack bonus for character...
        }
    }
