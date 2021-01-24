    <UserControl.Resources>
        <FrameworkElement x:Key="ProxyElement" DataContext="{Binding}" />
    </UserControl.Resources>
    
    <Grid>
        <DataGrid ItemsSource="{Binding Descriptions}">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Description"
                                    Width="{Binding Source={StaticResource ProxyElement}, Path=Width, Mode=TwoWay}"
                                    Binding="{Binding Description}" />
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
