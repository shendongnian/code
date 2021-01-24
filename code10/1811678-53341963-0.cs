    [Table("dbo.CW_FirmaCommunication")]
    public class CW_FirmaCommunication
    {
        [Key]
        [Column("Communnication_Id")]
        public int CommunicationId { get; set; }
        [Column("FC_VAT")]
        public int VatNumber { get; set; }
        public CW_Firma Firma { get; set; }
        [Column("FC_Data")]        
        public string FC_Data { get; set; }
    }
