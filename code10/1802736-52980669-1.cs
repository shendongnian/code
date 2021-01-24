    <ListView ItemsSource="{Binding aCollection}">
        <ListView.ItemTemplate>
            <DataTemplate>
                <ViewCell>
                    <StackLayout>
                        <Label Text="{Binding b.a, TargetNullValue='-'}"/>
                        <Label Text="{Binding c.a, TargetNullValue='-'}"/>
                        //***
                            <ListView ItemsSource="{Binding d.F}">
                              <ListView.ItemTemplate>
                                 <DataTemplate>
                                   <ViewCell>
                                      <StackLayout>
                                         <Entry Text="{Binding c}"/>
                                         <Entry Text="{Binding d}"/>
                                         <Entry Text="{Binding e}"/>
                                      </StackLayout>
                                   </ViewCell>
                                 </DataTemplate>
                              </ListView.ItemTemplate>
                            </ListView>
                        //***
                    </StackLayout>
                </ViewCell>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
