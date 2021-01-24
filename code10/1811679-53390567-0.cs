    public class CW_FirmaCommunication
	{
		[Key]
		public int FC_ID { get; set; }
		public int FC_VAT { get; set; }
		public int FC_Type { get; set; }
		public string FC_Data { get; set; }
        [ForeignKey("FC_VAT")]
		public virtual CW_Firma CwFirma { get; set; }
    }
    public class CW_Firma
	{
		[Key]
		public int F_VAT { get; set; }
    }
