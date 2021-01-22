    public class foo : FrameworkElement
    {
        private static readonly DependencyPropertyKey ReadOnlyIntPropertyKey =
            DependencyProperty.RegisterReadOnly( "ReadOnlyInt", typeof(int),
                                             typeof(foo), null);
        public int ReadOnlyInt
        {
           get { return (int)GetValue(ReadOnlyIntPropertyKey.DependencyProperty); }
        }
        public static readonly DependencyProperty ReadWriteStrProperty =
            DependencyProperty.Register( "ReadWriteStr", typeof(string), typeof(foo),
                                     new PropertyMetadata(ReadWriteStr_Changed));
        public string ReadWriteStr
        {
           get { return (string)GetValue(ReadWriteStrProperty); }
            set { SetValue(ReadWriteStrProperty, value); }
        }
        private static void ReadWriteStr_Changed(DependencyObject d,
                                            DependencyPropertyChangedEventArgs e)
        {
             foo f = d as foo;
             if (f != null)
             {
                  int iVal;
                  if (int.TryParse(f.ReadWriteStr, out iVal))
                      f.SetValue( ReadOnlyIntPropertyKey, iVal);
             }
        }
    }
