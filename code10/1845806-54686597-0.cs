    xmlns:i="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity"
    <Button Content="btnWithBehavior">
        <i:Interaction.Behaviors>
            <local:HandleButtonClick/>
        </i:Interaction.Behaviors>
    </Button>
    
    public class HandleButtonClick : Behavior<Button>
    {
    	protected override void OnAttached()
    	{
    		base.OnAttached();
    
    		AssociatedObject.Click += AssociatedObject_Click; ;
    	}
    	private void AssociatedObject_Click(object sender, RoutedEventArgs e)
    	{
    		//Move your MainWindow.Button_Click here;
    	}
    	protected override void OnDetaching()
    	{
    		base.OnDetaching();
    		AssociatedObject.Click -= AssociatedObject_Click;
    	}
    }
