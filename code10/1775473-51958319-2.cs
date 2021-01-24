    <ListView>
        <ListViewItem>Coll Programmer1</ListViewItem>
        <ListViewItem>MinecraftGeek1</ListViewItem>
        <ListViewItem>Steve</ListViewItem>
        <ListViewItem>John</ListViewItem>
        <ListView.ItemContainerStyle>
            <Style TargetType="ListViewItem">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="ListViewItem">
                            <Grid Name="RootPanel" Background="Transparent" Height="48">
                                <Rectangle Name="SelectedBorder" Width="8" Fill="#00C8FC"
                                       HorizontalAlignment="Left" Opacity="0.0" />
                                <ContentPresenter Margin="12 0 0 0" />
                            </Grid>
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsSelected" Value="True">
                                    <Trigger.EnterActions>
                                        <BeginStoryboard>
                                            <Storyboard>
                                                <DoubleAnimation
                                                    Storyboard.TargetName="SelectedBorder"
                                                    Storyboard.TargetProperty="Opacity"
                                                    To="1" Duration="0:0:0.25">
                                                </DoubleAnimation>
                                            </Storyboard>
                                        </BeginStoryboard>
                                    </Trigger.EnterActions>
                                    <Trigger.ExitActions>
                                        <BeginStoryboard>
                                            <Storyboard>
                                                <DoubleAnimation
                                                    Storyboard.TargetName="SelectedBorder"
                                                    Storyboard.TargetProperty="Opacity"
                                                    Duration="0:0:0.25">
                                                </DoubleAnimation>
                                            </Storyboard>
                                        </BeginStoryboard>
                                    </Trigger.ExitActions>
                                </Trigger>
                                <Trigger Property="IsMouseOver" Value="True">
                                    <Setter TargetName="RootPanel" Property="Background" Value="#00C8FC" />
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </ListView.ItemContainerStyle>
    </ListView>
