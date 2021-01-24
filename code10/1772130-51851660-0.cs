    <Style x:Key="FlashingHeader" TargetType="TabItem">
                <Setter Property="HeaderTemplate">
                    <Setter.Value>
                        <DataTemplate>
                            <!--Make The Header -->
                            <ContentControl x:Name="header"  Content="{Binding}" />
    
                            <!--Make The Background Flash-->
                            <DataTemplate.Triggers>
                                <Trigger Property="Visibility" Value="Visible">
                                    <Trigger.EnterActions>
                                        <BeginStoryboard>
                                            <Storyboard>
                                                <DoubleAnimation
                                                    Storyboard.TargetName="header"
                                                    Storyboard.TargetProperty="(ContentControl.Opacity)"
                                                    From="1" To="0" Duration="0:0:1" AutoReverse="True" RepeatBehavior="Forever" /> 
                                            </Storyboard>
                                        </BeginStoryboard>
                                    </Trigger.EnterActions>
                                </Trigger>
                            </DataTemplate.Triggers>
                        </DataTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
