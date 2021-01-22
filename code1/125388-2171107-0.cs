    public class BaseClass
    {
        protected BaseClass(BaseClass underlyingCharacterClass);
        public abstract bool CanCastSpells();
        public abstract List<Spell> GetAvailableSpells();
        protected BaseClass UnderlyingCharacterClass;
    }
    public class Wizard : BaseClass
    {
        public override bool CanCastSpells() { return true; }
        public override List<Spell> GetAvailableSpells()
        {
            List<Spell> result = new List<Spell>();
            if (UnderlyingCharacterClass != null)
                result.AddRange(UnderlyingCharacterClass.GetAvailableSpells());
            result.Add(new WizardSpell1());
            ...
            return result;
        }
    }
    public class Thief : BaseClass
    {
        public override bool CanCastSpells()
        {
            if (UnderlyingCharacterClass != null)
                return UnderlyingCharacterClass.CanCastSpells();
            return false;
        }
        public override List<Spell> GetAvailableSpells()
        {
            List<Spell> result = new List<Spell>();
            if (UnderlyingCharacterClass != null)
                result.AddRange(UnderlyingCharacterClass.GetAvailableSpells());
            return result;
        }
    }
