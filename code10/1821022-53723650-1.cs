    <Window.Resources>
        <ControlTemplate x:Key="TooltipPopupFadeAway" TargetType="ToolTip">
                        <Border Background="Yellow">
                        <TextBlock Text="{Binding PlacementTarget.Text, RelativeSource={RelativeSource AncestorType={x:Type ToolTip}}}"
                                   Name="TheText"
                                   />
                        </Border>
            <ControlTemplate.Triggers>
                <EventTrigger RoutedEvent="ToolTip.Opened">
                    <BeginStoryboard>
                        <Storyboard TargetProperty="Opacity">
                            <DoubleAnimation From="1.0" To="0" Duration="0:0:2" />
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger>
            </ControlTemplate.Triggers>
        </ControlTemplate>
    </Window.Resources>
    <Grid>
        <TextBox>
            <TextBox.ToolTip>
                <ToolTip Template="{StaticResource TooltipPopupFadeAway}"/>
            </TextBox.ToolTip> 
        </TextBox>
    </Grid>
