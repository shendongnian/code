    <Style x:Key="ContentChangedAnimated" TargetType="{x:Type local:CustomLabel}"
            BasedOn="{StaticResource {x:Type Label}}">
        <Style.Triggers>
            <EventTrigger RoutedEvent="ContentChanged">
                <EventTrigger.Actions>
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation Duration="0:0:2" Storyboard.TargetProperty="FontSize" 
                                                To="28" AutoReverse="True" />
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger.Actions>
            </EventTrigger>
        </Style.Triggers>
    </Style>
