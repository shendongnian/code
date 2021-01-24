    public class Spell
    {
        public Spell(string name, string typeOfDamage, double damage)
        {
            Name=name;
            TypeOfDamage=typeOfDamage; // consider using an enum?
            Damage=damage;
            // etc Add more properties here. I cant tell what type the other things in the array are
            // since they are all null.
            // some of these properties may be writable during their lifetime, so for those ones, add a 'set;' as well
        }
        public string Name { get; }
        public string TypeOfDamage { get; }
        public double Damage { get; }
    }
