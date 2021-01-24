    <ListBox ItemsSource="{Binding Objects}"
                SelectedItem="{Binding SelectedObject}">
        <ListBox.Resources>
            <DataTemplate DataType="{x:Type local:Unit}">
                <TextBlock>
                    <Run Text="Unit, Id:"/>
                    <Run  Text="{Binding Id}"/>
                </TextBlock>
            </DataTemplate>
            <DataTemplate DataType="{x:Type local:Component}">
                <TextBlock>
                    <Run Text="Component, Id:"/>
                    <Run  Text="{Binding Id}"/>
                </TextBlock>
            </DataTemplate>
        </ListBox.Resources>
    </ListBox>
    <ContentControl Grid.Column="1" Content="{Binding SelectedObject}">
        <ContentControl.Resources>
            <DataTemplate DataType="{x:Type local:Unit}">
                <StackPanel>
                    <TextBlock Text="{Binding Id}"/>
                    <TextBlock Text="{Binding UnitData}"/>
                </StackPanel>
            </DataTemplate>
            <DataTemplate DataType="{x:Type local:Component}">
                <StackPanel>
                    <TextBlock Text="{Binding Id}"/>
                    <TextBlock Text="{Binding ComponentData}"/>
                </StackPanel>
            </DataTemplate>
        </ContentControl.Resources>
    </ContentControl>
