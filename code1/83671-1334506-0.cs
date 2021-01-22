      public class displayclass
      {
        public string ElementName { get; set; }
        public XElement Element { get; set; }
        public override string ToString()
        {
          return ElementName;
        }
      }
