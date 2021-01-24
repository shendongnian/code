    public static Dictionary<Text, List<string>>[] CotisationURSSAF(TnsPrimitiveSession primitiveSession, int _IndexEnCours, CTNSExercice _Exercice, bool isAjustee)
    {
         Dictionary<Text, List<string>> CotisationURSSAF = new Dictionary<Text, List<string>>();
         Dictionary<Text, List<string>> ElementsPrisEnCompte = new Dictionary<Text, List<string>>();
         return new[]{ CotisationURSSAF, ElementsPrisEnCompte };
    }
