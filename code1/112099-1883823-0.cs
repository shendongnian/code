    public abstract class AbsWizard
    {
        public abstract Magic GetMagic(String magicword);
        public abstract string[] GetAvalibleSpells();
    }
    
    public class WhiteWizard : AbsWizard
    {
        // organizes all the spells available to the wizard...
        public sealed class Spells
        {
            // NOTE: Spells may be better off as a specific class, rather than as strings.
            // Then you could decorate them with a lot of other information (cost, category, etc).
            public const string Abracadabra = "Abracadabra";
            public const string AlaPeanutButterSandwiches = "APBS";
        }
    }
    
    public static void CastMagic()
    {
        Type[] types = System.Reflection.Assembly.GetExecutingAssembly().GetTypes();
        List<Type> wizardTypes = new List<string>();
        List<string> avalibleSpells = new List<string>();
        Type selectedWizardType;
        string selectedSpell;
        foreach (Type t in types)
        {
            if (typeof(AbsWizard).IsAssignableFrom(t))
            {
                // find a nested class named Spells and search it for public spell definitions
                // better yet, use an attribute to decorate which class is the spell lexicon
                var spellLexicon = Type.FromName( t.FullName + "+" + "Spells" );
                foreach( var spellField in spellLexicon.GetFields() )
                   // whatever you do with the spells...
            }
        }
    }
