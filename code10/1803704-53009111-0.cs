    public static Dictionary<Text, List<string>>[] CotisationURSSAF(TnsPrimitiveSession primitiveSession, int _IndexEnCours, CTNSExercice _Exercice, bool isAjustee)
    {
        var list = new List<Dictionary<Text, List<string>>>();    
        Dictionary<Text, List<string>> CotisationURSSAF = new Dictionary<Text, List<string>>();    
        Dictionary<Text, List<string>> ElementsPrisEnCompte = new Dictionary<Text, List<string>>();    
        list.Add(CotisationURSSAF);
        list.Add(ElementsPrisEnCompte);   
        return list.ToArray();       
    }
