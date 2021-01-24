    public class ListaPrelievoDettaglioUbicazioni
    {
        public int BinAbsEntry { get; set; }
        public int Quantity { get; set; }    
        // public string AllowNegativeQuantity { get; set; }
        // public int SerialAndBatchNumbersBaseLine { get; set; }
        public int BaseLineNumber { get; set; }
        public virtual ListaPrelievoDettaglio Lista { get; set; }
    }
