    // Abstractions project
    interface ICharacter
    {
        string Name { get; } 
    }
    interface IWarrior : ICharacter
    {
        void Attack();
    }
    interface IWizard : ICharacter
    {
        void CastSpell();
    }
    interface IVisitor
    {
        void Visit(IWarrior w);
        void Visit(IWizard w);
    }
    // implementations project
    abstract class CharacterBase : ICharacter
    {
        public string Name { get; }
        public abstract void Accept(IVisitor v);
    }
    class Warrior : CharacterBase, IWarrior
    {
        public void Attack()
        {
            // do warrior things
        }
        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }
    }
    class Wizard : CharacterBase, IWizard
    {
        public void CastSpell()
        {
            // do wizardly things
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
