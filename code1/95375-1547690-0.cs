    <ComboBox>
       <ComboBox.ItemTemplate>
           <DataTemplate>
               <Grid>
                    <Grid.ColumnDefinitions>
                         <ColumnDefinition Width="100"/>
                         <ColumnDefinition Width="200"/>
                         <ColumnDefinition Width="100"/>
                    </Grid.ColumnDefinitions>
                    <TextBlock Grid.Column="0" Text="{Binding CustomerName}"/>
                    <TextBlock Grid.Column="1" Text="{Binding CustomerEmail}"/>
                    <TextBlock Grid.Column="2" Text="{Binding CustomerPhone}"/>
               </Grid>
           </DataTemplate>
       </ComboBox.ItemTemplate>
    </ComboBox>
