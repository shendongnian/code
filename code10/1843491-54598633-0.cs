    <!-- LoadingCircles Style for a Control-Element-->
    <Style TargetType="{x:Type Control}" x:Key="LoadingCircles">
        <!-- Set default values (can be overridden) -->
        <Setter Property="Foreground" Value="Black"/>
        <Setter Property="Tag" Value="20"/>
        <!-- Hide Control when its not enabled -->
        <Setter Property="Visibility" Value="Collapsed"/>
        <!-- Define the lok of the Control -->
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate>
                    <!-- Use ViewBox for auto-scaling -->
                    <Viewbox Stretch="Fill">
                        <!-- Set Grid Size to absolute value to scale on 100% (like Circle Size = 20 -> 20%) -->
                        <Grid Height="100" Width="100" RenderTransformOrigin="0.5,0.5">
                            <Grid.Resources>
                                <!-- Define Template for Circle on a circular path whereas the Tag defines the initial Rotation (0 = top, 180 = bottom) -->
                                <Style TargetType="{x:Type ContentPresenter}">
                                    <Setter Property="DataContext" Value="{Binding}"/>
                                    <Setter Property="ContentTemplate">
                                        <Setter.Value>
                                            <DataTemplate>
                                                <Border Height="100">
                                                    <Border.LayoutTransform>
                                                        <RotateTransform Angle="{Binding Tag, RelativeSource={RelativeSource TemplatedParent}}"/>
                                                    </Border.LayoutTransform>
                                                    <Ellipse Width="{Binding Tag, RelativeSource={RelativeSource AncestorType=Control}}" Height="{Binding Tag, RelativeSource={RelativeSource AncestorType=Control}}" Fill="{Binding Foreground, RelativeSource={RelativeSource AncestorType=Control}}" VerticalAlignment="Top"/>
                                                </Border>
                                            </DataTemplate>
                                        </Setter.Value>
                                    </Setter>
                                </Style>
                            </Grid.Resources>
                          
                            <!-- Add Circles to the circular Path with their start-roation and opacity -->
                            <ContentPresenter Opacity="0.1" Tag="36"/>
                            <ContentPresenter Opacity="0.2" Tag="72"/>
                            <ContentPresenter Opacity="0.3" Tag="108"/>
                            <ContentPresenter Opacity="0.4" Tag="144"/>
                            <ContentPresenter Opacity="0.5" Tag="180"/>
                            <ContentPresenter Opacity="0.6" Tag="216"/>
                            <ContentPresenter Opacity="0.7" Tag="252"/>
                            <ContentPresenter Opacity="0.8" Tag="288"/>
                            <ContentPresenter Opacity="0.9" Tag="324"/>
                            <ContentPresenter Opacity="1" Tag="0"/>
                            <!-- Define Roation for all the Circles in the "Container" -->
                            <Grid.RenderTransform>
                                <RotateTransform Angle="0" x:Name="AngleEverything"/>
                            </Grid.RenderTransform>
                                
                        </Grid>
                    </Viewbox>
                    <!-- Define Trigger when the Control is enabled -->
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsEnabled" Value="True">
                            <!-- When set, start the "Container" rotation -->
                            <Trigger.EnterActions>
                                <BeginStoryboard x:Name="Rotation">
                                    <Storyboard RepeatBehavior="Forever">
                                        <DoubleAnimation Storyboard.TargetName="AngleEverything" Storyboard.TargetProperty="Angle" From="0" To="359" Duration="00:00:03"/>
                                    </Storyboard>
                                </BeginStoryboard>
                            </Trigger.EnterActions>
                            <!-- when unset, stop the "Container" rotation -->
                            <Trigger.ExitActions>
                                <StopStoryboard Storyboard.TargetName="Rotation"/>
                            </Trigger.ExitActions>
                            <!-- Show control when it is enabled (otherwise hide, see Setter at the top) -->
                            <Setter Property="Visibility" Value="Visible"/>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
