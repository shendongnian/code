    <GridView x:Name="cosmosData" ItemClick="cosmosData_ItemClick" IsItemClickEnabled="True" IsSwipeEnabled="true" SelectionMode="Single">
    <GridView.ItemTemplate>
        <DataTemplate x:DataType="local:TableData">
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="200"/>
                    <ColumnDefinition Width="200"/>
                </Grid.ColumnDefinitions>
                <TextBlock Grid.Column="0" Text="{x:Bind File_Name_At_Upload}" />
                <ItemsControl Grid.Column="1" ItemsSource="{x:Bind ObjectsDetected}">
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding className}"/>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
            </Grid>
        </DataTemplate>
    </GridView.ItemTemplate>
