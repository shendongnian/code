    <ItemsControl ItemsSource="{Binding Vwr.Table.Vals, UpdateSourceTrigger=PropertyChanged}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal" x:Name="Item">
                <TextBlock x:Name="SearchCol" Text="{Binding Col}" Style="{StaticResource tabTextBlock}"/>
                <TextBox x:Name="SearchText" Text="{Binding Filter, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" Width="200">
                    <i:Interaction.Triggers>
                        <i:EventTrigger EventName="TextChanged">
                            <i:InvokeCommandAction Command="{Binding Path=DataContext.Modules.SelectedModule.Vwr.Table.FilterCommand, RelativeSource={RelativeSource Mode=FindAncestor,
                                         AncestorType={x:Type Window}}, UpdateSourceTrigger=PropertyChanged}" CommandParameter="{Binding ElementName=Item, Path=DataContext}"/>
                        </i:EventTrigger>
                    </i:Interaction.Triggers>
                </TextBox>
                <TextBlock Text="{Binding CTStr}" Style="{StaticResource tabTextBlock}"/>
                </StackPanel>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
