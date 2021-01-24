    <ListView x:Name="ListViewObjectMapping" Margin="0,0,0,-5">
        <ListView.View>
            <GridView>
                <GridViewColumn x:Name="GridViewColumnCategoryButtonHidden" Header="Category" Width="200">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <ComboBox x:Name="ComboBoxButtonHidden" ItemsSource="{Binding Path=Value.LinkedInstances}" SelectedValue="{Binding Path=Value.LinkedInstance}" Width="{Binding Path=Width, Mode=OneWay, ElementName=GridViewColumnCategoryButtonHidden}"/>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>    
                <GridViewColumn x:Name="GridViewColumnCategoryButtonVisible" Header="Category" Width="200">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <Border Margin="-6">
                                <ComboBox x:Name="ComboBoxButtonVisible" ItemsSource="{Binding Path=Value.LinkedInstances}" SelectedValue="{Binding Path=Value.LinkedInstance}" Width="{Binding Path=Width, Mode=OneWay, ElementName=GridViewColumnCategoryButtonVisible}"/>
                            </Border>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>    
            </GridView>
        </ListView.View>
    </ListView>
