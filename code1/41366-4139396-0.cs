using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace MyBehaviours
{
	public class FocusBehaviour
	{
		#region IsFocused
		public static bool GetIsFocused(Control control)
		{
			return (bool) control.GetValue(IsFocusedProperty);
		}
		public static void SetIsFocused(Control control, bool value)
		{
			control.SetValue(IsFocusedProperty, value);
		}
		public static readonly DependencyProperty IsFocusedProperty = DependencyProperty.RegisterAttached(
			"IsFocused", 
			typeof(bool),
			typeof(FocusBehaviour), 
			new UIPropertyMetadata(false, IsFocusedPropertyChanged));
		public static void IsFocusedPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			var control = sender as Control;
			if (control == null || !(e.NewValue is bool))
				return;
			if ((bool)e.NewValue && !(bool)e.OldValue)
				control.Focus();
		}
		#endregion IsFocused
		#region IsListBoxItemSelected
		public static bool GetIsListBoxItemSelected(Control control)
		{
			return (bool) control.GetValue(IsListBoxItemSelectedProperty);
		}
		public static void SetIsListBoxItemSelected(Control control, bool value)
		{
			control.SetValue(IsListBoxItemSelectedProperty, value);
		}
		public static readonly DependencyProperty IsListBoxItemSelectedProperty = DependencyProperty.RegisterAttached(
			"IsListBoxItemSelected", 
			typeof(bool),
			typeof(FocusBehaviour), 
			new UIPropertyMetadata(false, IsListBoxItemSelectedPropertyChanged));
		public static void IsListBoxItemSelectedPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			var control = sender as Control;
			DependencyObject p = control;
			while (p != null && !(p is ListBoxItem))
			{
				p = VisualTreeHelper.GetParent(p);
			} 
			if (p == null)
				return;
			((ListBoxItem)p).IsSelected = (bool)e.NewValue;
		}
		#endregion IsListBoxItemSelected
	}
}
