    <CollectionViewSource x:Key="groups" Source="{Binding}" >
        <CollectionViewSource.GroupDescriptions>
            <PropertyGroupDescription PropertyName="Name" />
        </CollectionViewSource.GroupDescriptions>
    </CollectionViewSource>
    <DataTemplate x:Key="contactTemplate" DataType="Contact">
        <TextBlock x:Name="tb" Text="{Binding Name}" />
            <DataTemplate.Triggers>
                <DataTrigger Binding="{Binding IsOnline}" Value="False">
                    <Setter TargetName="tb" Property="Foreground" Value="Gray" />
                </DataTrigger>
            </DataTemplate.Triggers>
    </DataTemplate>
    <ListBox ItemsSource="{Binding Source={StaticResource groups}}">
        <ListBox.GroupStyle>
            <GroupStyle HeaderTemplate="{StaticResource groupTemplate}" />
        </ListBox.GroupStyle>
        <ListBox.ItemTemplate>
            <DataTemplate DataType="Contact">
                <ListBox ItemsSource="{Binding Contacts}">
                    <ListBox.ItemTemplate>
                        <DataTemplate DataType="Contact">
                            <TextBlock Text="{Binding Name}" />
                        </DataTemplate>
                    </ListBox.ItemTemplate>
                </ListBox>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
        
