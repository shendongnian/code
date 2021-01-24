    <DataGrid Name="Result" IsReadOnly="True" ItemsSource="{Binding Result}" AutoGenerateColumns="False" Height="200">
        <DataGrid.Columns>
            <DataGridTemplateColumn Header="Image">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <StackPanel>
                            <Button  Content="{Binding Image}" Name="Image" Click="Button_Click" />
                        </StackPanel>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
