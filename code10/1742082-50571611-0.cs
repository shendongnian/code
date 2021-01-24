    <ListView x:Name="lvConnections">
            <ListView.ItemContainerStyle>
                <Style TargetType="{x:Type ListViewItem}">
                    <EventSetter Event="MouseDoubleClick" Handler="ListViewItem_MouseDoubleClick" />
                </Style>
            </ListView.ItemContainerStyle>
            <ListView.Resources>
                <Style TargetType="ListViewItem">
                   <Setter Property="Background" Value="{Binding Color}"/>
                </Style>
            </ListView.Resources>
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition/>
                        </Grid.ColumnDefinitions>
                        <Grid.RowDefinitions>
                            <RowDefinition/>
                        </Grid.RowDefinitions>
                        <StackPanel  Width="150" MaxHeight="50" Grid.Column="0" Grid.Row="0" Orientation="Horizontal" >
                            <TextBlock VerticalAlignment="Center" Text="{Binding Name}" FontWeight="ExtraBlack" TextWrapping="Wrap" Padding="10"/>
                        </StackPanel>
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
