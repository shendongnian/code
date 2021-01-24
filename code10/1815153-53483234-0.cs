    class ComboDisplay<TSource>
    {
         public string Display {get; set;}
         public TSource Value {get; set;}
    }
    cmbRoom.DisplayMember = nameof(ComboDisplay.Display);
    cmbRoom.ValueMember = nameof(ComboDisplay.Value);
