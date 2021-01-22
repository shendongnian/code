    public ReadOnlyWrapper : PropertyDescriptor
    {
       private readonly innerPropertyDescriptor;
       public ReadOnlyWrapper(PropertyDescriptor inner)
       {
           this.innerPropertyDescriptor = inner;
       }
       public override bool IsReadOnly
       {
           get
           {
               return true;
           }
       }
       // override all other abstract members here to pass through to the
       // inner object, I only show it for one method here:
       public override object GetValue(object component)
       {
           return this.innerPropertyDescriptor.GetValue(component);
       }
    }                
