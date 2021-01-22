            public class Nifty
        {
            private static double _tiny;
            private static double _small;
            private static double _medium;
            private static double _large;
            private static double _huge;
            private static bool _resourcesLoaded;
            #region Margins
            public static readonly DependencyProperty MarginProperty =
                DependencyProperty.RegisterAttached("Margin", typeof(string), typeof(Nifty),
                    new PropertyMetadata(string.Empty,
                        new PropertyChangedCallback(OnMarginChanged)));
            public static Control GetMargin(DependencyObject d)
            {
                return (Control)d.GetValue(MarginProperty);
            }
            public static void SetMargin(DependencyObject d, string value)
            {
                d.SetValue(MarginProperty, value);
            }
            private static void OnMarginChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                FrameworkElement ctrl = d as FrameworkElement;
                if (ctrl == null)
                    return;
                string Margin = (string)d.GetValue(MarginProperty);
                ctrl.Margin = ConvertToThickness(Margin);
            }
            private static Thickness ConvertToThickness(string Margin)
            {
                var result = new Thickness();
                if (!_resourcesLoaded)
                {
                    _tiny = (double)Application.Current.FindResource("TinySpace");
                    _small = (double)Application.Current.FindResource("SmallSpace");
                    _medium = (double)Application.Current.FindResource("MediumSpace");
                    _large = (double)Application.Current.FindResource("LargeSpace");
                    _huge = (double)Application.Current.FindResource("HugeSpace");
                    _resourcesLoaded = true;
                }
                result.Left = CharToThickness(Margin[0]);
                result.Top = CharToThickness(Margin[1]);
                result.Bottom = CharToThickness(Margin[2]);
                result.Right = CharToThickness(Margin[3]);
                return result;
            }
            private static double CharToThickness(char p)
            {
                switch (p)
                {
                    case 't':
                    case 'T':
                        return _tiny;
                    case 's':
                    case 'S':
                        return _small;
                    case 'm':
                    case 'M':
                        return _medium;
                    case 'l':
                    case 'L':
                        return _large;
                    case 'h':
                    case 'H':
                        return _huge;
                    default:
                        return 0.0;
                }
            }
            #endregion
        }
