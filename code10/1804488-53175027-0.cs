    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition />
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition />
            <ColumnDefinition />
        </Grid.ColumnDefinitions>
        <Controls:FlyoutsControl Grid.Column="1">
            <Controls:Flyout x:Name="yourMahAppFlyout" Header="Flyout" Background="AliceBlue" Position="Right" Width="350" 
                             IsOpen="{Binding ElementName=FlyoutOverview, Path=IsChecked}">
                <TextBlock Text="My Flyout is here" />
            </Controls:Flyout>
        </Controls:FlyoutsControl>
        <ListBox Grid.Row="0" Grid.Column="0" ItemsSource="{Binding NameList}">
            <ListBox.ContextMenu>
                <ContextMenu>
                    <MenuItem x:Name="FlyoutOverview" Header="Menu 1" IsCheckable="True" 
                              IsChecked="{Binding IsMenuItem1Checked}">
                        <MenuItem.Icon>
                            <iconPacks:PackIconModern Kind="GlobeWire"/>
                        </MenuItem.Icon>
                    </MenuItem>
                    <Separator/>
                    <MenuItem Header="Menu 2"/>
                    <Separator/>
                    <MenuItem Header="Menu 3">
                        <MenuItem.Icon>
                            <iconPacks:PackIconModern Kind="People"/>
                        </MenuItem.Icon>
                    </MenuItem>
                    <MenuItem Header="Menu 4">
                        <MenuItem.Icon>
                            <iconPacks:PackIconModern Kind="UserDelete"/>
                        </MenuItem.Icon>
                    </MenuItem>
                    <MenuItem Header="Menu 5">
                        <MenuItem.Icon>
                            <iconPacks:PackIconModern Kind="ControlResume"/>
                        </MenuItem.Icon>
                    </MenuItem>
                </ContextMenu>
            </ListBox.ContextMenu>
        </ListBox>
    </Grid>
