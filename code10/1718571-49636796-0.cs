    <Window.DataContext>
        <local:MainWIndowViewModel/>
    </Window.DataContext>
    <Grid>
        <ListView ItemsSource="{Binding Rows}">
            <ListView.View >
                <GridView >
                    <GridViewColumn Header="Col 1" Width="100">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <Button Content="{Binding Col1.Content}"
                                        Command="{Binding Col1.Command}"
                                        />
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn Header="Col 2" Width="100">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <Button Content="{Binding Col2.Content}"
                                        Command="{Binding Col2.Commmand}"
                                        />
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                </GridView>
            </ListView.View>
        </ListView>
    </Grid>
