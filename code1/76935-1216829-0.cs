      public class PstnNumber
      {
        public virtual string Number { get; set; }
        public PstnNumber() { }
        public PstnNumber(string number) { this.Number = number; }
        public AutoFormatNumber { get { return Numer.PadLeft(10, '0'); } }
      }
