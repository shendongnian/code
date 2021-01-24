    public class ObserveEmpty : Behavior<TextBox>
    {
    	public Control TargetControl
    	{
    		get { return (Control)GetValue(TargetControlProperty); }
    		set { SetValue(TargetControlProperty, value); }
    	}
    	public static readonly DependencyProperty TargetControlProperty =
    		DependencyProperty.Register(nameof(TargetControl), typeof(object), typeof(ObserveEmpty), new PropertyMetadata(null, TargetCtlChanged));
    
    	private static void TargetCtlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    	{
    		(d as ObserveEmpty)?.SetTargetBackground();
    	}
    	public Brush TargetBgrndBrushOnEmpty { get; set; }
    	public Brush TargetBgrndBrush { get; set; }
    
    
    	protected override void OnAttached()
    	{
    		base.OnAttached();
    		SetTargetBackground();
    		AssociatedObject.TextChanged += AssociatedObject_TextChanged;
    	}
    	protected override void OnDetaching()
    	{
    		base.OnDetaching();
    		AssociatedObject.TextChanged -= AssociatedObject_TextChanged;
    	}
    	private void AssociatedObject_TextChanged(object sender, TextChangedEventArgs e)
    	{
    		SetTargetBackground();
    	}
    	private void SetTargetBackground()
    	{
    		if (TargetControl != null)
    		{
    			var brush = string.IsNullOrEmpty(AssociatedObject?.Text) ? TargetBgrndBrushOnEmpty : TargetBgrndBrush;
    
    			TargetControl.Background = brush;
    
    			var dgrClmnHdr = TargetControl as DataGridColumnHeader;
    			if (dgrClmnHdr?.Column != null)
    			{
    				Style style = new Style(typeof(DataGridCell));
    				style.Setters.Add(new Setter(DataGridCell.BackgroundProperty, brush));
    				dgrClmnHdr.Column.CellStyle = style;
    			}
    		}
    	}
    }
    
    xmlns:i="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity"
        <DataGrid.Resources>
            <Style TargetType="{x:Type DataGridColumnHeader}">
                <Setter Property="ContentTemplate">
                    <Setter.Value>
                        <DataTemplate>
                            <StackPanel>
                                <TextBlock x:Name="myBlock" Text="{Binding}" TextWrapping="Wrap" />
                                <TextBox x:Name="myBox">
                                    <i:Interaction.Behaviors>
                                        <local:ObserveEmpty TargetBgrndBrush="Aqua" TargetBgrndBrushOnEmpty="Red" 
                                                            TargetControl="{Binding RelativeSource={RelativeSource AncestorType=DataGridColumnHeader}, Mode=OneWay}"/>
                                    </i:Interaction.Behaviors>
                                </TextBox>
                            </StackPanel>
                        </DataTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </DataGrid.Resources>
