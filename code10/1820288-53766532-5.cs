	using System.Windows.Interactivity;
	...
	
		public class SyncedColumnWidthsBehavior : Behavior<DataGrid>
		{
			protected override void OnAttached()
			{
				this.AssociatedObject.LoadingRow += this.SyncColumnWidths;
			}
			protected override void OnDetaching()
			{
				this.AssociatedObject.LoadingRow -= this.SyncColumnWidths;
			}
			private void SyncColumnWidths(object sender, DataGridRowEventArgs e)
			{
				var dataGrid = this.AssociatedObject;
				foreach (DataGridColumn c in dataGrid.Columns)
					c.Width = 0;
				e.Row.UpdateLayout();
				foreach (DataGridColumn c in dataGrid.Columns)
					c.Width = DataGridLength.Auto;
			}
		}
		
