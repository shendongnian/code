    public class Travel : LocalizedRessourceSubscriber
    {
        private Ressource<string> Ressource1 = null;
        private Ressource<string> Ressource2 = null;
        public String TravelName { 
            get { return GetRessource<string>(Ressource2); }
            set { SetRessource<string>(Ressource1, value); } 
        }
        public String TravelDescription {
            get { return GetRessource<string>(Ressource2); }
            set { SetRessource<string>(Ressource2, value); } 
        }
    }
    public class LocalizedRessourceSubscriber
    {
        protected T GetRessource<T>(Ressource<T> Source)
        {
            return LocaleHelper.GetRessource<T>(Source);
        }
        protected void SetRessource<T>(Ressource<T> Source, T Value)
        {
           (Source ?? 
               (Source = new Ressource<T>())
                    ).DefaultValue = Value;
        }
    }
