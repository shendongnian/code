     <UserControl.Resources>
        <ResourceDictionary>
            <DataTemplate DataType="{x:Type jobDetails:JobProductionAddOnViewModel}">
                <jobDetails:JobProductionAddOnView />
            </DataTemplate>
            <DataTemplate DataType="{x:Type forms:FormsDetailViewModel}">
                <forms:FormsDetailView />
            </DataTemplate>
            <DataTemplate DataType="{x:Type labels:LabelsDetailViewModel}">
                <labels:LabelsDetailView />
            </DataTemplate>
            <DataTemplate DataType="{x:Type plastics:PlasticsDetailViewModel}">
                <plastics:PlasticsDetailView />
            </DataTemplate>
            <DataTemplate DataType="{x:Type specialtyCoatings:SpecialtyCoatingsDetailViewModel}">
                <specialtyCoatings:SpecialtyCoatingsDetailView />
            </DataTemplate>
            <DataTemplate DataType="{x:Type digitalLabels:DigitalLabelDetailViewModel}">
                <digitalLabels:DigitalLabelDetailView />
            </DataTemplate>
        </ResourceDictionary>
    </UserControl.Resources>
    <Grid>
        <TabControl ItemsSource="{Binding TabItems}"
                    controls:TabControlHelper.IsUnderlined="True" 
                    controls:TabControlHelper.Transition="Left"
                    TabStripPlacement="Left"
                    SelectedIndex="{Binding SelectedIndex}"
                    ItemContainerStyle="{StaticResource ProductionTabItem}">
            <TabControl.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Header}"
                               Width="150"/>
                </DataTemplate>
            </TabControl.ItemTemplate>
            <TabControl.ContentTemplate>
                <DataTemplate>
                    <ContentControl Content="{Binding ViewModel}" />
                </DataTemplate>
            </TabControl.ContentTemplate>
        </TabControl>
    </Grid>
