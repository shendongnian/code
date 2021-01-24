    <Grid Margin="3, 8, 3, 3"
          HorizontalAlignment="Stretch"
          VerticalAlignment="Stretch">
        <TabControl ItemsSource="{Binding TabItems}"
                    SelectedItem="{Binding SelectedTab,
                                   UpdateSourceTrigger=PropertyChanged}">
            <TabControl.ItemTemplate>
                <DataTemplate>
                    <Label Content="{Binding DisplayName}" />
                </DataTemplate>
            </TabControl.ItemTemplate>
            <TabControl.ContentTemplate>
                <DataTemplate>
                    <ContentControl cal:View.Model="{Binding}" />
                </DataTemplate>
            </TabControl.ContentTemplate>
        </TabControl>
    </Grid>
