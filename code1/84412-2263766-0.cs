        public PermissionEnum Permission
        {
            get { return (PermissionEnum)GetValue(PermissionProperty); }
            set { SetValue(PermissionProperty, value); }
        }
        public static readonly DependencyProperty PermissionProperty =
            DependencyProperty.Register("Permission", typeof(PermissionEnum), typeof(SecurityMenuItem), new FrameworkPropertyMetadata(PermissionEnum.DeliveryView));
