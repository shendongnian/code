    <Grid>
        <ListView ItemsSource="{Binding ItemsCollection}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <local:UserControl1>
                        <i:Interaction.Triggers>
                            <i:EventTrigger EventName="MouseDoubleClick">
                                <i:InvokeCommandAction Command="{Binding DoubleClickCommand,ElementName=Main}"
                                                   CommandParameter="{Binding data}" />
                            </i:EventTrigger>
                        </i:Interaction.Triggers>
                    </local:UserControl1>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
