        public class ReturnModel
        {
            public Dictionary<Text, List<string>> CotisationURSSAF { get; set; }
            public Dictionary<Text, List<string>> ElementsPrisEnCompte { get; set; }
            public ReturnModel(Dictionary<Text, List<string>> cotisationURSSAF, Dictionary<Text, List<string>> elementsPrisEnCompte)
            {
                this.CotisationURSSAF = cotisationURSSAF;
                this.ElementsPrisEnCompte = elementsPrisEnCompte;
            }
        }
