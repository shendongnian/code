      <ListView ItemsSource="{Binding EditableItems}" >
            <ListView.View>
                <GridView >
                    <GridViewColumn Header="Databases" Width="498">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <TextBox  Text="{Binding .}" />
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                </GridView>
            </ListView.View>
        </ListView>
