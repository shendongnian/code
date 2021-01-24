    <TabControl ItemsSource="{Binding Items}" SelectedItem="{Binding SelectedItem, Mode=TwoWay}">
        <TabControl.ItemTemplate>
            <DataTemplate DataType="local:Item">
                <TextBlock Text="{Binding Header}" />          
            </DataTemplate>
        </TabControl.ItemTemplate>
        <TabControl.ContentTemplate>
            <DataTemplate DataType="local:Item">
                <TextBox Text="{Binding TextFile, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" AcceptsReturn="True" TextWrapping="Wrap">
                    <i:Interaction.Behaviors>
                        <local:LineCountBehavior LineCount="{Binding LineCount, Mode=OneWayToSource}"/>
                    </i:Interaction.Behaviors>
                </TextBox>
            </DataTemplate>
        </TabControl.ContentTemplate>
    </TabControl>
