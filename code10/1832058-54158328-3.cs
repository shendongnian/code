    <ItemsControl Grid.Row="0" ItemsSource="{Binding Path=Columns, ElementName=dataGrid}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <StackPanel Orientation="Horizontal"/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <TextBox Width="{Binding ActualWidth}">
                    <TextBox.Resources>
                        <local:ListIndexToValueConverter x:Key="listIndexToValueConverter"/>
                    </TextBox.Resources>
                    <TextBox.Text>
                        <MultiBinding Converter="{StaticResource listIndexToValueConverter}" UpdateSourceTrigger="PropertyChanged">
                            <Binding Path="DataContext.Filters" ElementName="userControl"/>
                            <Binding Path="DisplayIndex"/>
                        </MultiBinding>
                    </TextBox.Text>
                </TextBox>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
    <DataGrid x:Name="dataGrid" Grid.Row="1" ItemsSource="{Binding Users}">
        <DataGrid.Columns>
            <DataGridTextColumn DisplayIndex="0" Width="*" Binding="{Binding FirstName}"/>
            <DataGridTextColumn DisplayIndex="1" Width="*" Binding="{Binding LastName}"/>
            <DataGridTextColumn DisplayIndex="2" Width="*" Binding="{Binding Age}"/>
        </DataGrid.Columns>
    </DataGrid>
