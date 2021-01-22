    public class EnumFlags<T> : INotifyPropertyChanged where T : struct, IComparable, IFormattable, IConvertible
    {
      private T value;
      public EnumFlags(T t)
      {
        if (!typeof(T).IsEnum) throw new ArgumentException($"{nameof(T)} must be an enum type"); // I really wish they would just let me add Enum to the generic type constraints
        value = t;
      }
      public T Value
      {
        get { return value; }
        set
        {
          if (this.value.Equals(value)) return;
          this.value = value;
          OnPropertyChanged("Item[]");
        }
      }
      [IndexerName("Item")]
      public bool this[string key]
      {
        get
        {
          int val = (int)Enum.Parse(typeof(T), key);
          return (((int)(object)value & val) == val);
        }
        set
        {
          int val = (int)Enum.Parse(typeof(T), key);
          if ((((int)(object)this.value & val) == val) == value) return;
          this.value = (T)(object)((int)(object)this.value ^ val);
          
          OnPropertyChanged("Item[]");
        }
      }
      #region INotifyPropertyChanged
      public event PropertyChangedEventHandler PropertyChanged;
      private void OnPropertyChanged([CallerMemberName] string memberName = "")
      {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
      }
      #endregion
    }
