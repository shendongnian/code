    <DockPanel>
        <Grid DockPanel.Dock="Top">
            <!-- Grid stuff here -->
            <ListView></ListView>
        </Grid>
        
        <StatusBar DockPanel.Dock="Bottom"                   
                   VerticalAlignment="Bottom">
            <StatusBar.ItemsPanel>
                <ItemsPanelTemplate>
                    <Grid>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="*" />
                        </Grid.RowDefinitions>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="100" />
                            <ColumnDefinition Width="Auto" />
                            <ColumnDefinition Width="*" />
                            <ColumnDefinition Width="Auto" />
                            <ColumnDefinition Width="100" />
                        </Grid.ColumnDefinitions>
                    </Grid>
                </ItemsPanelTemplate>
            </StatusBar.ItemsPanel>
            <StatusBarItem Grid.Column="0">
                <TextBlock Text="Item1"/>
            </StatusBarItem>
            <Separator Grid.Column="1" />
            <StatusBarItem Grid.Column="2">
                <TextBlock />
            </StatusBarItem>
            <Separator Grid.Column="3" />
            <StatusBarItem Grid.Column="4">
                <TextBlock Text="AnotherItem" />
            </StatusBarItem>
        </StatusBar>
    </DockPanel>
