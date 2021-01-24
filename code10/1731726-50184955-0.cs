    abstract class ControleurBase
    {
        public virtual T Créer<T>(ConteneurControle conteneurControle)
        {
            var actualType = typeof(T); // use this instead of the Type parameter
            dynamic modele = null;
    
            //Stuff that creates my model  
    
            return (T)modele;
        }
    }
    
    class ControleurÉtudiant : ControleurBase
    {
        public static List<Étudiant> Etudiant { get; set; }
    
        public Étudiant Créer(ConteneurControle conteneurControle)
        {
            return base.Créer<Étudiant>(conteneurControle);
        }
    }
