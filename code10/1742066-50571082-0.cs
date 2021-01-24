    var contacts = await Plugin.ContactService.CrossContactService.Current.GetContactListAsync();
    lstContacts.ItemsSource = contacts;
      <ListView 
        x:Name="lstContacts"
            <ListView.ItemTemplate>
                <DataTemplate>
                    <ViewCell>
                        <StackLayout>
                            <Label Text="{Binding Name}"/>
                            <Label Text="{Binding Email}"/>
                            <Label Text="{Binding Number}"/>
                        </StackLayout>
                    </ViewCell>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
