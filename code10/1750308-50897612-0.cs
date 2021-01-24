    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <ComboBox Grid.Column="0" 
                  x:Name="ClientsComboBox" 
                  ItemsSource="{Binding Clients}"/>
        <ListBox Grid.Column="1" 
                 ItemsSource="{Binding ElementName=ClientsComboBox, Path=SelectedItem.rory}"/>
        <ListBox Grid.Column="2"
                 ItemsSource="{Binding ElementName=ClientsComboBox, Path=SelectedItem.lokaty}"/>
        <ListBox Grid.Column="3"
                 ItemsSource="{Binding ElementName=ClientsComboBox, Path=SelectedItem.debety}"/>
    </Grid>
