    <Window.Resources>
        <BooleanToVisibilityConverter x:Key="BooleanToVisibilityConverter"/>
    </Window.Resources>
    <Grid>
        <ItemsControl ItemsSource="{Binding Cells}">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <UniformGrid Columns="64"/>
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Rectangle Width="10" Height="10" Fill="Green"
                               Visibility="{Binding IsVisible,
                                   Converter={StaticResource BooleanToVisibilityConverter}}"/>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </Grid>
