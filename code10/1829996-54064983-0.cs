    public class Book
    {
        public List<Text> AssociatedTexts { get; set; }
        public string Name { get; set; }
        public int BookID { get; set; }
        
        public Book(int bookID, string name, IEnumerable<Text> assocText)
        {
            BookID = bookID;
            Name = name;
            AssociatedTexts = assocText.ToList();
        }
        public void addAssociatedText(Text text)
        {
            AssociatedTexts.Add(text);
        }
        
        public bool removeAssociatedText(int textID)
        {
            bool ret = false;
            if (AssociatedTexts.Count > textID)
            {
                AssociatedTexts.RemoveAt(textID);
                ret = true;
            }
            else
            {
                ret = false;
            }
            return ret;
        }
        
        public Part lookupAssociatedTexts(int searchPart)
        {
            for (int i = 0; i < AssociatedTexts.Count; i++)
            {
                if (AssociatedTexts[i].TextID == searchPart)
                {
                    return AssociatedTexts[i];
                }
            }
            return null;
        }
    }
