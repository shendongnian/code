     <Grid>
        <DataGrid ItemsSource="{Binding OrderDataGridItems }" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Column1" Width="Auto" Binding="{Binding CountryName}" />
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
