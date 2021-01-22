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
      public bool this[T key]
      {
        get
        {
          // .net does not allow us to specify that T is an enum, so it thinks we can't cast T to int.
          // to get around this, cast it to object then cast that to int.
          return (((int)(object)value & (int)(object)key) == (int)(object)key);
        }
        set
        {
          if ((((int)(object)this.value & (int)(object)key) == (int)(object)key) == value) return;
          this.value = (T)(object)((int)(object)this.value ^ (int)(object)key);
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
