    public abstract class Spell
    {
       public string Name { get; set; }
       public int ManaCost { get; set; }
       public Spell(string name, int manaCost)
       {
          Name = name;
          ManaCost = manaCost;
       }
       public void Cast(Creature caster, Creature targetCreature)
       {
           caster.SubtractMana(ManaCost); //might throw NotEnoughManaException? 
           ApplySpell(caster, targetCreature);
       }
       protected abstract void ApplySpell(Creature caster, Creature targetCreature);
    }
