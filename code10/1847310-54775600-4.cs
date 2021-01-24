		<Style x:Key="TreeViewItemStyle" TargetType="TreeViewItem">
			<Style.Triggers>
				<Trigger Property="DataContext" Value="Hardware">
					<Setter Property="ItemsSource" Value="{Binding DataContext.Hardware, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type TreeViewItem}, AncestorLevel=1}}" />
				</Trigger>
				<Trigger Property="DataContext" Value="Inputs">
					<Setter Property="ItemsSource" Value="{Binding DataContext.Inputs, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type TreeViewItem}, AncestorLevel=1}}" />
				</Trigger>
					<Trigger Property="DataContext" Value="Outputs">
					<Setter Property="ItemsSource" Value="{Binding DataContext.Outputs, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type TreeViewItem}, AncestorLevel=1}}" />
				</Trigger>
			</Style.Triggers>
		</Style>
