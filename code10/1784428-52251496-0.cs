	<DataGrid.Resources>
		<attached:BindingProxy x:Key="proxy" Data="{Binding}"/>
	</DataGrid.Resources>
	<DataGridTemplateColumn>
		<DataGridTemplateColumn.Header>
			<CheckBox IsChecked="{Binding Data.IsHeaderCheckBoxChecked, Source={StaticResource proxy}}"/>
		</DataGridTemplateColumn.Header>
		<DataGridTemplateColumn.CellTemplate>
			<DataTemplate>
				<CheckBox IsChecked="{Binding IsSelected, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}"/>
			</DataTemplate>
		</DataGridTemplateColumn.CellTemplate>
	</DataGridTemplateColumn>
BindingProxy
	public class BindingProxy : Freezable
	{
		#region XAML Properties
	
		public static readonly DependencyProperty DataProperty =
			DependencyProperty.Register(nameof(Data), typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
	
		public object Data
		{
			get { return GetValue(DataProperty); }
			set { SetValue(DataProperty, value); }
		}
	
		#endregion
		
		#region Freezable
	
		protected override Freezable CreateInstanceCore()
		{
			return new BindingProxy();
		}
	
		#endregion
	}
