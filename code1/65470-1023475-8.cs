    public class SynonymManager
    { 
        private readonly IDictionary<string, Synonym>> synonyms = new
            Dictionary<string, Synonym>>();
    
        private void Add(Synonym synonym)
        {
            // This will overwrite any existing synonym with the same name
            synonyms[synonym.Name] = synonym;
        }
        public void SomeFunction()
        { // Just a function to add 2 sysnonyms to 1 stock
            Stock stock = GetStock("General Motors");
            Synonym otherName = new Synonym("GM", stock);
            Add(otherName);
            ListOfSynonyms.Add(otherName);
            otherName = new Synonym("Gen. Motors", stock);
            Add(otherName);
        }
    
        public Synonym Find(string nameSynonym)
        {
           // This will throw an exception if you don't have
           // a synonym of the right name. Do you want that?
           return synonyms[nameSynonym];
        }
    }
