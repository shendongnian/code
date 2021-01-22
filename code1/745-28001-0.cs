    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;
    
    namespace Helpers
    {
        public class TextBoxNumbers
        {    
            public static Decimal GetSingleDelta(DependencyObject obj)
            {
                return (Decimal)obj.GetValue(SingleDeltaProperty);
            }
    
            public static void SetSingleDelta(DependencyObject obj, Decimal value)
            {
                obj.SetValue(SingleDeltaProperty, value);
            }
    
            // Using a DependencyProperty as the backing store for SingleValue.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty SingleDeltaProperty =
                DependencyProperty.RegisterAttached("SingleDelta", typeof(Decimal), typeof(TextBoxNumbers), new UIPropertyMetadata(0.0m, new PropertyChangedCallback(f)));
    
    
            public static void f(DependencyObject o, DependencyPropertyChangedEventArgs e)
            {
                TextBox t = o as TextBox;
                if (t == null)
                    return;
    
                t.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(t_PreviewKeyDown);
            }
    
            private static Decimal GetSingleValue(DependencyObject obj)
            {
                return GetSingleDelta(obj);
            }
    
            private static Decimal GetDoubleValue(DependencyObject obj)
            {
                return GetSingleValue(obj) * 10;
            }
    
            private static Decimal GetTripleValue(DependencyObject obj)
            {
                return GetSingleValue(obj) * 100;
            }
    
            static void t_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
            {
                TextBox t = sender as TextBox;
                if (t == null)
                    return;
    
                Decimal i;
                if (!Decimal.TryParse(t.Text, out i))
                    return;
    
                switch (e.Key)
                {
                    case System.Windows.Input.Key.Up:
                        if (Keyboard.Modifiers == ModifierKeys.Shift)
                            i += GetDoubleValue(t);
                        else
                            i += GetSingleValue(t);
                        break;
                    case System.Windows.Input.Key.Down:
                        if (Keyboard.Modifiers == ModifierKeys.Shift)
                            i -= GetDoubleValue(t);
                        else
                            i -= GetSingleValue(t);
                        break;
                    case System.Windows.Input.Key.PageUp:
                        i += GetTripleValue(t);
                        break;
                    case System.Windows.Input.Key.PageDown:
                        i -= GetTripleValue(t);
                        break;
                    default:
                        return;
                }
    
                if (BindingOperations.IsDataBound(t, TextBox.TextProperty))
                {
                    try
                    {
                        Binding binding = BindingOperations.GetBinding(t, TextBox.TextProperty);
                        t.Text = (string)binding.Converter.Convert(i, null, binding.ConverterParameter, binding.ConverterCulture);
                    }
                    catch
                    {
                        t.Text = i.ToString();
                    }
                }
                else
                    t.Text = i.ToString();
            }
        }
    }
