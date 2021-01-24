    class Brand
    {
        public string Name { get; set; }
        public Rate Rate { get; set; }
        public void SelectBrand() => OnBrandSelect?.Invoke(this, Rate);
        public event EventHandler<Rate> OnBrandSelect;
    }
