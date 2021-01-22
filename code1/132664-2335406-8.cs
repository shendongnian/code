    class IntegerFormField : FormFieldBase<int>
    {
         public IntegerFormField(int value, string name) : base(value, name) { }
    }
            
    class DecimalFormField : FormFieldBase<decimal>
    {
         public DecimalFormField(Decimal value, string name) : base(value, name) { }
    }
