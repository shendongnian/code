    abstract class FormFieldBase<T> : IFormField<T>
            {
                private readonly T _value;
        
                public FormFieldBase(T value, string name)
                {
                    _value = value;
                    Name = name;
                }
        
                #region IFormField<T> Members
        
                public virtual T GetValue()
                {
                    return _value;
                }
        
                #endregion
        
                #region IFormField Members
        
                object IFormField.GetValue()
                {
                    return _value;
                }
        
                public string Name { get; private set; }
        
                #endregion
            }
