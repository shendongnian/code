    <DataTemplate x:Key="OptionViewTemplate" DataType={x:Type local:OptionView}>
       <Grid>
           <Grid.ColumnDefinitions>
              <ColumnDefinition SharedSizeGroup="Name"/>
              <ColumnDefinition SharedSizeGroup="Value"/>
           </Grid.ColumnDefinitions>
           <Label Content="{Binding Name}" Grid.Column="0"/>
           <TextBox Text="{Binding Value}" Grid.Column="1"/>
       </Grid>
    </DataTemplate>
    ...
    <ItemsControl Grid.IsSharedSizeScope="True"
        ItemsSource="{DynamicResource OptionCollection}"/>
