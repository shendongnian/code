        <!-- This Border is animated. -->
        <Border Height="300" Margin="68,434,1506,335" >
            <Border.Style>
                <Style TargetType="{x:Type Border}">
                    <!-- Here is your animation -->
                    <Style.Triggers>
                        <EventTrigger RoutedEvent="Border.Loaded">
                            <BeginStoryboard Name="RandomStoryboard">
                                <Storyboard >
                                    <RectAnimation Storyboard.TargetProperty="Background.(ImageBrush.Viewport)"
                                To="0,0,1,1" RepeatBehavior="Forever" />
                                </Storyboard>
                            </BeginStoryboard>
                            <!-- Stop the animation at the Start -->
                            <PauseStoryboard BeginStoryboardName="RandomStoryboard" />
                        </EventTrigger>
                        <!-- Control the animation according to the Togglebutton State -->
                        <DataTrigger Binding="{Binding Path=IsChecked, ElementName=SpinControl}" Value="True">
                            <DataTrigger.EnterActions>
                                <ResumeStoryboard BeginStoryboardName="RandomStoryboard" />
                            </DataTrigger.EnterActions>
                            <DataTrigger.ExitActions>
                                <PauseStoryboard BeginStoryboardName="RandomStoryboard" />
                            </DataTrigger.ExitActions>
                            <!-- Hide the Border while the animation is running -->
                            <Setter Property="Border.Visibility" Value="Hidden"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Border.Style>
        </Border>
        <!-- This Button Controls the Animated Border -->
        <ToggleButton Name="SpinControl">
                <ToggleButton.Style>
                    <Style TargetType="{x:Type ToggleButton}">
                        <Setter Property="Content" Value="Start"/>
                        <Style.Triggers>
                            <Trigger Property="IsChecked" Value="True">
                                <Setter Property="Content" Value="Stop"/>
                            </Trigger>
                        </Style.Triggers>
                    </Style>
                </ToggleButton.Style>
            </ToggleButton>
