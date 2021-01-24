    <ItemsControl ItemsSource="{Binding Presentation}" VirtualizingPanel.ScrollUnit="Pixel">
        <ItemsControl.Template>
            <ControlTemplate>
                <ScrollViewer CanContentScroll="True" Focusable="False">
                    <ItemsPresenter />
                </ScrollViewer>
            </ControlTemplate>
        </ItemsControl.Template>
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <VirtualizingStackPanel 
                    Orientation="Vertical" 
                    IsVirtualizing="True"
                    VirtualizationMode="Recycling">
                </VirtualizingStackPanel>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                    <MyControl Item="{Binding Monday}" Grid.Column="0" ... />
                    ...
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate
    </ItemsControl>
