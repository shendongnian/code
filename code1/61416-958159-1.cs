    <DockPanel>
      <Label Content="{Binding Path=Identifier.Name, Mode=OneWay}" />
      <ListBox ItemsSource="{Binding Path=Values, Mode=OneWay}"
               Grid.IsSharedSizeScope="True">
        <ListBox.ItemTemplate>
          <DataTemplate>
            <Grid>
              <Grid.ColumnDefinitions>
                <ColumnDefinition SharedSizeGroup="OptionColumn" />
                <ColumnDefinition SharedSizeGroup="ValueColumn" />
              </Grid.ColumnDefinitions>
              <TextBlock Grid.Column="0" Text="{Binding Option}" />
              <TextBlock Grid.Column="1" Text="{Binding Value}" />
            </Grid>
          </DataTemplate>
        </ListBox.ItemTemplate>
      </ListBox>
    </DockPanel>
