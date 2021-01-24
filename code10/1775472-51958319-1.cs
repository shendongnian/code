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
                                <Rectangle Name="SelectedBorder" Width="8" Fill="#00c9fe"
                                           HorizontalAlignment="Left" Visibility="Collapsed" />
                                <ContentPresenter Margin="12 0 0 0" />
                            </Grid>
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsSelected" Value="True">
                                    <Setter TargetName="SelectedBorder" Property="Visibility" Value="Visible" />
                                </Trigger>
                                <Trigger Property="IsMouseOver" Value="True">
                                    <Setter TargetName="RootPanel" Property="Background" Value="#00c9fe" />
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </ListView.ItemContainerStyle>
    </ListView>
