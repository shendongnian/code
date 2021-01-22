    public abstract class MagicSchool
    {
        public abstract string[] AvailableSpells { get; }
        public abstract Wizard CreateWizard();
    }
    public abstract class Wizard
    {
        protected Wizard(MagicSchool school)
        {
            School = school;
        }
        public abstract Cast(string spell);
        MagicSchool School 
        {
            public get; 
            protected set;
        }
    }
    public class BlackMagic : MagicSchool
    {
        public override AvailableSpells
        {
            get
            {
                return new string[] { "zoogle", "xclondon" };
            }
        }
        public override Wizard CreateWizard()
        {
            return new BlackWizard(this);
        }
    }
    public class BlackWizard : Wizard
    {
        public BlackWizard(BlackMagic school)
            : base(school)
        {
            // etc
        }
        public override Cast(string spell)
        {
            // etc.
        }
    }
    // continue for other wizard types
