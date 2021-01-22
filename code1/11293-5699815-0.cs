    public static readonly System.Windows.DependencyProperty $PropertyName$Property =
            System.Windows.DependencyProperty.Register("$PropertyName$",
                                                       typeof ($PropertyType$),
                                                       typeof ($OwnerType$));
        public $PropertyType$ $PropertyName$
        {
            get { return ($PropertyType$) GetValue($PropertyName$Property); }
            set { SetValue($PropertyName$Property, value); }
        }
    $END$
