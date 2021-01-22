    public partial class PaymentControl : ViewUserControl<CheckoutModel>
        {
            public IEnumerable<SelectListItem> ExpirationMonthDropdown
            {
                get
                {
                    return Enumerable.Range(1, 12).Select(x =>
    
                        new SelectListItem()
                        {
                            Text = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames[x - 1] + " (" + x + ")",
                            Value = x.ToString(),
                            Selected = (x == Model.ExpirationMonth)
                        });
                }
            }
    
            public IEnumerable<SelectListItem> ExpirationYearDropdown
            {
                get
                {
                    return Enumerable.Range(DateTime.Today.Year, 20).Select(x =>
    
                    new SelectListItem()
                    {
                        Text = x.ToString(),
                        Value = x.ToString(),
                        Selected = (x == Model.ExpirationYear)
                    });
                }
            }
        }
