    public class Spell
    {
        public int castRange;
    
        public virtual Spell Copy()
        {
            Spell spell = new Spell();
            spell.castRange = this.castRange;
            return spell;
        }
    }
    public class ManaSpell : Spell
    {
        public int manaCost;
    
        public override Spell Copy()
        {
            ManaSpell spell = new ManaSpell();
            spell.castRange = this.castRange;
            spell.manaCost = this.manaCost;
            return spell;
        }
    }
