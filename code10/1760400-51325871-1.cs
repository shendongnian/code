    <EventTrigger RoutedEvent="ContentChanged">
        <EventTrigger.Actions>
            <BeginStoryboard>
                <Storyboard>
                    <ColorAnimation BeginTime="0:0:0" Duration="0:0:1" 
                                    Storyboard.TargetProperty="(Label.Background).(SolidColorBrush.Color)" 
                                    To="Yellow"/>
                    <ColorAnimation BeginTime="0:0:1" Duration="0:0:1" 
                                    Storyboard.TargetProperty="(Label.Background).(SolidColorBrush.Color)" 
                                    To="White"/>
                </Storyboard>
            </BeginStoryboard>
        </EventTrigger.Actions>
    </EventTrigger>
