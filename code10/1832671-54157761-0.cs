    <ListBox x:Name="listBoxDutyDays" ItemsSource="{Binding tour}">
     <ListBox.ItemTemplate>
         <DataTemplate>
             <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="*"/>
                    <ColumnDefinition Width="*"/>
                </Grid.ColumnDefinitions>
                <Label Grid.Column="0" Content="{Binding Day}"/>
                <Label Grid.Column="1" Content="{Binding Date}"/>
            </Grid>
        </DataTemplate>
     </ListBox.ItemTemplate>
