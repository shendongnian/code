    <DataGrid Name="dataGrid1" ItemsSource="{Binding Path=Items}" CanUserAddRows="False" CanUserDeleteRows="False" CanUserResizeRows="False" HeadersVisibility="Column" GridLinesVisibility="None" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding Path=Uri, Mode=OneWay}" Header="Uri" IsReadOnly="True" />
            <DataGridTextColumn Binding="{Binding Path=Size, Mode=OneWay}" Header="Size" IsReadOnly="True" />
            <DataGridTemplateColumn Header="Progress">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <ProgressBar Value="{Binding Path=Progress, Mode=OneWay}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
            <DataGridTextColumn Binding="{Binding Path=Eta, Mode=OneWay}" Header="Eta" IsReadOnly="True" />
            <DataGridTextColumn Binding="{Binding Path=Priority, Mode=OneWay}" Header="Priority" IsReadOnly="True" />
        </DataGrid.Columns>
    </DataGrid>
