    Style x:Key="ListBoxItemStyle1" TargetType="{x:Type ListBoxItem}">
            <Style.Triggers>
                <EventTrigger RoutedEvent="ListViewItem.MouseEnter">
                    <EventTrigger.Actions>
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation Storyboard.TargetProperty="Opacity"                               
                              From="0.0" To="1.0" Duration="0:0:0.5" AutoReverse="False" SpeedRatio="2" />
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger.Actions>
                </EventTrigger>
                <EventTrigger RoutedEvent="ListViewItem.MouseLeave">
                    <EventTrigger.Actions>
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation Storyboard.TargetProperty="Opacity"                               
                              From="1.0" To="0.0" Duration="0:0:0.5" AutoReverse="False" SpeedRatio="2" />
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger.Actions>
                </EventTrigger>
            </Style.Triggers>
        </Style>
