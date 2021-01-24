	using System.Threading.Tasks;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Interactivity;
	namespace YourApp.Behaviors
	{
		public class ToolTipBehavior : Behavior<FrameworkElement>
		{
			private ToolTip CurrentToolTip;
			public ListViewItem ListViewItem
			{
				get { return (ListViewItem)GetValue(ListViewItemProperty); }
				set { SetValue(ListViewItemProperty, value); }
			}
			// Using a DependencyProperty as the backing store for ListViewItem.  This enables animation, styling, binding, etc...
			public static readonly DependencyProperty ListViewItemProperty =
				DependencyProperty.Register("ListViewItem", typeof(ListViewItem), typeof(ToolTipBehavior),
					new PropertyMetadata(null, (d, e) => (d as ToolTipBehavior)?.OnListViewItemChanged(e)));
			private void OnListViewItemChanged(DependencyPropertyChangedEventArgs e)
			{
				if (e.OldValue is ListViewItem)
					(e.OldValue as ListViewItem).Selected -= ToolTipBehavior_Selected;
				if (e.NewValue is ListViewItem)
					(e.NewValue as ListViewItem).Selected += ToolTipBehavior_Selected;
			}
			private void ToolTipBehavior_Selected(object sender, RoutedEventArgs e)
			{
				if (e.Source != e.OriginalSource)
					return;
				if ((this.ListViewItem != null) && this.ListViewItem.IsSelected)
				{
					var tooltip = this.AssociatedObject.ToolTip as ToolTip;
					if (tooltip != null)
					{
						if (this.CurrentToolTip != tooltip)
						{
							if (this.CurrentToolTip != null)
								this.CurrentToolTip.Opened -= Tooltip_Opened;
							this.CurrentToolTip = tooltip;
							if (this.CurrentToolTip != null)
								this.CurrentToolTip.Opened += Tooltip_Opened;
						}
						this.CurrentToolTip.PlacementTarget = this.AssociatedObject;
						this.CurrentToolTip.IsOpen = true;
					}
				}
			}
			private async void Tooltip_Opened(object sender, RoutedEventArgs e)
			{
				await Task.Delay(1000);
				(this.AssociatedObject.ToolTip as ToolTip).IsOpen = false;
			}
		}
	}
