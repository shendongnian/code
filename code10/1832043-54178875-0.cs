    public static readonly DependencyProperty ActionsProperty =
    	DependencyProperty.Register("Actions", typeof(ObservableCollection<UIElement>), typeof(ModalWindow), new UIPropertyMetadata(new ObservableCollection<UIElement>()));
    
    public ObservableCollection<UIElement> Actions
    {
    	get => (ObservableCollection<UIElement>)GetValue(ActionsProperty);
    	set => SetValue(ActionsProperty, value);
    }
---
    <ItemsControl Grid.Row="1" ItemsSource="{TemplateBinding Actions}">
    	<ItemsControl.ItemsPanel>
    		<ItemsPanelTemplate>
    			<StackPanel Orientation="Horizontal" HorizontalAlignment="Right" />
    		</ItemsPanelTemplate>
    	</ItemsControl.ItemsPanel>
    </ItemsControl>
