    public class Field
    {
       private Type _type;
       private int _maximumLength;
       private string _name;
       object _value;
    
       public Field(Type type, string name, int maximumLength)
       {
          _type = type;
          _maximumLength = maximumLength;
          _name = name;
       }         
    
       public Object Value
       {
          get
          {
             return _value;
          }
          set
          {
             if (value.ToString().Length > _maximumLength)
             {
                throw new SomeException(string.Format("{0} cannot exceed {1} in length.", _name, _maximumValue));
             }
             else
             {
                _value = value;
                OnPropertyChanged(_name);
             }
          }
       }
    }
