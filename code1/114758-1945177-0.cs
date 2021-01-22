        <toolkit:DataGrid Name="datagrid" Margin="0,0,0,28" AutoGenerateColumns="False">
            <toolkit:DataGrid.Columns>
                <toolkit:DataGridTextColumn Header="First Name" Binding="{Binding FirstName}"/>
                <toolkit:DataGridTemplateColumn Header="Last Name">
                    <toolkit:DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBox Text="{Binding LastName}"/>
                        </DataTemplate>
                    </toolkit:DataGridTemplateColumn.CellTemplate>
                </toolkit:DataGridTemplateColumn>
            </toolkit:DataGrid.Columns>
        </toolkit:DataGrid>
        <Button Height="22" VerticalAlignment="Bottom" Click="Button_Click" />
