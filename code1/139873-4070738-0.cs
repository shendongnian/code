    [Required(ErrorMessage = "مبلغ پیشنهادی را وارد کنید")]
    [RegularExpression("^[+]?\\d*$", ErrorMessage = "*")]
    public object FirstlySum { get; set; }
    public decimal FirstlySumTranslated {
        get { return decimal.Parse(FirstlySum); }
    }
