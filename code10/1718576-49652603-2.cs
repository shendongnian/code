        <ListView x:Name="listBox">
            <ListView.View>
                <GridView x:Name="gridview">
                    <GridViewColumn Header="col1" Width="200">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <ContentControl Content="{Binding Col1}" />
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn Header="col2" Width="200">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <ContentControl Content="{Binding Col2}" />
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                </GridView>
            </ListView.View>
        </ListView>
