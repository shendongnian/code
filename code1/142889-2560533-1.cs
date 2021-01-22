    class ComboElement
    {
         public String ComboElementText { get; set; }
         public int Index { get; set; }
        public ComboElement(String elementText, int index)
        {
           ComboElementText = elementText;
           Index = index;
        }
    }
    
    //* List of hidden elements.
    List<ComboElement> hiddenElements = new List<ComboElement>();
    
