    <DataGrid Grid.Row="1" Grid.Column="0" Grid.ColumnSpan="3" Grid.RowSpan="3" Margin="10" ItemsSource="{Binding SearchResults}" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Term" Binding="{Binding SearchedTopic}"/>
                <DataGridTextColumn Header="Match Count" Binding="{Binding FoundPaths.Count}" />
            </DataGrid.Columns>
            <DataGrid.RowDetailsTemplate>
                <DataTemplate>
                    <DataGrid Margin="5" ItemsSource="{Binding FoundPaths}" AutoGenerateColumns="False">
                        <DataGrid.Columns>
                            <DataGridTextColumn Header="Found" Binding="{Binding}"/>
                        </DataGrid.Columns>
                    </DataGrid>
                </DataTemplate>
            </DataGrid.RowDetailsTemplate>
        </DataGrid>
