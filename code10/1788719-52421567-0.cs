    public class CrossRef{
        [Display(Name = "MANUFACTURER")]
        [...]
        public string Manufacturer { get; set; }
    }
    // ...
    gridControl1.DataSource = new BindingList<CrossRef> {
        new CrossRef() { Manufacturer = ... },
        ...
    };
    
