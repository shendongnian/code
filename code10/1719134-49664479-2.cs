        <ListView Loaded="FrameworkElement_OnLoaded" x:Name="Items">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition/>
                            <ColumnDefinition/>
                        </Grid.ColumnDefinitions>
                        <TextBlock x:Name="RowContent" Text="{Binding Name}"/>
                        <ToggleSwitch x:Name="Toggle" Grid.Column="1" Toggled="Toggle_OnToggled"/>
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
