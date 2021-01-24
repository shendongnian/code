    <ListView Name="HeaderList"  ItemsSource="{Binding Items}" >
        <ListView.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Border Background="Bisque">
                        <TextBlock Text="{Binding Test}"/>
                    </Border>
    
                    <ListView Name="SubItemsList" ItemsSource="{Binding SubItems}" 
                               IsItemClickEnabled="True" 
                               SelectedItem="{Binding SelectItme,Mode=TwoWay}" >
                        <ListView.ItemTemplate>
                            <DataTemplate>
                                <StackPanel Orientation="Vertical">
                                    <TextBlock Text="{Binding }"/>
                                </StackPanel>
                            </DataTemplate>
                        </ListView.ItemTemplate>
    
                        <i:Interaction.Behaviors >
                            <ic:EventTriggerBehavior  EventName="ItemClick">
                                <ic:InvokeCommandAction  Command="{Binding ItemCommand}" 
                                                         CommandParameter="{Binding}" />
                            </ic:EventTriggerBehavior>
                        </i:Interaction.Behaviors>
                    </ListView>
                </Grid>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
