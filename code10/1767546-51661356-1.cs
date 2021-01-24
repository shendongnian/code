    <StackLayout>
        <Entry x:Name="Entry_NewValue" TextChanged="Entry_NewValue_TextChanged"/>
        <ListView x:Name="_ListView" ItemSelected="_ListView_ItemSelected">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <ViewCell>
                        <Grid>
                            <Grid.Resources>
                                <local:ViewCell_Converter x:Key="ViewCell_Converter"/>
                            </Grid.Resources>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="2*"/>
                                <ColumnDefinition Width="*"/>
                            </Grid.ColumnDefinitions>
                            <Label Grid.Column="0" Text="{Binding UserName}"/>
                            <Label Grid.Column="1" Text="{Binding UserValue, Converter={StaticResource ViewCell_Converter}}"/>
                        </Grid>
                    </ViewCell>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </StackLayout>
