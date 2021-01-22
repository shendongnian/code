    using System;
    
        using System.Windows;
        using System.Windows.Controls;
        using System.Windows.Media;
        
        namespace ToggleTest
    
    {
        /// <summary>
        /// Interaction logic for ToggleButton.xaml
        /// </summary>
        public partial class MyToggleButton : UserControl
        {
            public MyToggleButton()
            {
                InitializeComponent();
            }
    
    
            public static readonly DependencyProperty EnabledUncheckedProperty =
                DependencyProperty.Register(
                "EnabledUnchecked",
                typeof(ImageSource),
                typeof(MyToggleButton),
                new PropertyMetadata(onEnabledUncheckedChangedCallback));
    
            public ImageSource EnabledUnchecked
            {
                get { return (ImageSource)GetValue(EnabledUncheckedProperty); }
                set { SetValue(EnabledUncheckedProperty, value); }
            }
    
            static void onEnabledUncheckedChangedCallback(
                DependencyObject dobj,
                DependencyPropertyChangedEventArgs args)
            {
                //do something if needed
            }
    
            public static readonly DependencyProperty DisabledUncheckedProperty =
                DependencyProperty.Register(
                "DisabledUnchecked",
                typeof(ImageSource),
                typeof(MyToggleButton),
                new PropertyMetadata(onDisabledUncheckedChangedCallback));
    
            public ImageSource DisabledUnchecked
            {
                get { return (ImageSource)GetValue(DisabledUncheckedProperty); }
                set { SetValue(DisabledUncheckedProperty, value); }
            }
    
            static void onDisabledUncheckedChangedCallback(
                DependencyObject dobj,
                DependencyPropertyChangedEventArgs args)
            {
                //do something if needed
            }
    
    
            public static readonly DependencyProperty EnabledCheckedProperty =
                DependencyProperty.Register(
                "EnabledChecked",
                typeof(ImageSource),
                typeof(MyToggleButton),
                new PropertyMetadata(onEnabledCheckedChangedCallback));
    
            public ImageSource EnabledChecked
            {
                get { return (ImageSource)GetValue(EnabledCheckedProperty); }
                set { SetValue(EnabledCheckedProperty, value); }
            }
    
            static void onEnabledCheckedChangedCallback(
                DependencyObject dobj,
                DependencyPropertyChangedEventArgs args)
            {
                //do something if needed
            }
    
    
            public static readonly DependencyProperty IsCheckedProperty =
                DependencyProperty.Register(
                "IsChecked",
                typeof(Boolean),
                typeof(MyToggleButton),
                new PropertyMetadata(onCheckedChangedCallback));
    
            public Boolean IsChecked
            {
                get { return (Boolean)GetValue(IsCheckedProperty); }
                set { if(value != IsChecked) SetValue(IsCheckedProperty, value); }
            }
    
            static void onCheckedChangedCallback(
                DependencyObject dobj,
                DependencyPropertyChangedEventArgs args)
            {
                //do something, if needed
            }
    
    
    
        }
    }
