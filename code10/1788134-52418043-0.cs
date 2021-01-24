    <Window
    ...
    xmlns:i="clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity" >
        <i:Interaction.Triggers>
        <userInterface:RoutedEventTrigger RoutedEvent="{x:Static Validation.ErrorEvent}" >
            <userInterface:ViewErrorCounterAction ViewErrorCounter="{Binding Path=ViewValidationErrorCount, Mode=TwoWay}"/>
        </userInterface:RoutedEventTrigger>
    </i:Interaction.Triggers>
