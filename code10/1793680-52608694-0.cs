     <Grid.Resources>
            <Storyboard x:Key="slideRight">
                <Storyboard>
                    <DoubleAnimation
                        AutoReverse="True"
                        RepeatBehavior="Forever"
                        Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[0].(TranslateTransform.X)"
                        From="0"
                        To="1000"
                        Duration="0:0:0.3" />
                </Storyboard>
            </Storyboard>
            <Style TargetType="StackPanel">
                <Setter Property="Background" Value="Green" />
                <Setter Property="RenderTransform">
                    <Setter.Value>
                        <TransformGroup>
                            <TranslateTransform X="0" Y="0" />
                        </TransformGroup>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsChecked, ElementName=MenuButton1}" Value="True">
                        <DataTrigger.EnterActions>
                            <BeginStoryboard Storyboard="{StaticResource slideRight}" />
                        </DataTrigger.EnterActions>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Grid.Resources>
