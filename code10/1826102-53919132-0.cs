                void _OnChildChanged(
                    DependencyObject sender,
                    DependencyPropertyChangedEventArgs e)
                {
                    if (e.NewValue != e.OldValue)
                    {
                        Console.WriteLine("Child Changed!");
                    }
                }
