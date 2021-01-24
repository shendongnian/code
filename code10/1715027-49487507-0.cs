    <ListBox x:Name="listbox" HorizontalAlignment="Left" Height="68" Margin="71,354,0,0" VerticalAlignment="Top" Width="395">
       <ListBox.ItemTemplate>
          <DataTemplate>
              <Grid>
                  <Grid.ColumnDefinitions>
                      <ColumnDefinition Width="*" />
                      <ColumnDefinition Width="Auto" />
                  </Grid.ColumnDefinitions>
                  <TextBlock Text="{Binding Text}" />
                  <CheckBox Grid.Column="1" IsChecked="{Binding IsChecked, Mode=TwoWay}" />
              </Grid>
          </DataTemplate>
       </ListBox.ItemTemplate>
    </ListBox>
        
