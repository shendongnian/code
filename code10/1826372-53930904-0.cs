    public class YourModelClass
    {
        ..........
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#.#}")]
        public decimal CurrentSoftMin { get; set; }
        ..........
    }
