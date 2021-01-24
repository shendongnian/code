    public class FieldValidatorEntity
    {
        public int Id { get; set; }
        public int CartOptionalId { get; set; }
        public CartOptional CartOptional { get; set; }
        public FieldValidator Value { get; set; }
        // other columns
    }
