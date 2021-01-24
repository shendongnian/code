    public static DependencyProperty IsEditingProperty =
                        DependencyProperty.Register(
                                "IsEditing",
                                typeof(bool),
                                typeof(EditBox),
                                new FrameworkPropertyMetadata(false)
                                );
