    public class Magic
    {
    }
    public abstract class AbsWizard
    {
        public abstract Magic GetMagic(String magicword);
        public abstract string[] GetAvalibleSpells();
        internal AbsWizard()
        {
        }
    }
    public class WhiteWizard : AbsWizard
    {
        public override Magic GetMagic(string magicword)
        {
            return new Magic();
        }
        public override string[] GetAvalibleSpells()
        {
            string[] spells = { "booblah", "zoombar" };
            return spells;
        }
    }
    public static class WizardFactory
    {
        private static Dictionary<string, List<AbsWizard>> _spellsList = new Dictionary<string, List<AbsWizard>>();
        /// <summary>
        /// Take the wizard and add his spells to the global spell pool.  Then register him with that spell.
        /// </summary>
        /// <param name="wizard"></param>
        private static void RegisterWizard(AbsWizard wizard)
        {
            foreach (string s in wizard.GetAvalibleSpells())
            {
                List<AbsWizard> lst = null;
                if (!_spellsList.TryGetValue(s, out lst))
                {
                    _spellsList.Add(s, lst = new List<AbsWizard>());
                }
                lst.Add(wizard);
            }
        }
        public string[] GetGlobalSpellList()
        {
            List<string> retval = new List<string>();
            foreach (string s in _spellsList.Keys)
            {
                retval.Add(s);
            }
            return retval.ToArray<string>();
        }
        public List<AbsWizard> GetWizardsWithSpell(string spell)
        {
            List<AbsWizard> retval = null;
            _spellsList.TryGetValue(spell, out retval);
            return retval;
        }
        static WizardFactory()
        {
            RegisterWizard(new WhiteWizard());
        }
    }
