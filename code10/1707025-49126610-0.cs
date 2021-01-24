      <DataGrid x:Name="unitTable" ItemsSource="{Binding Units}" AutoGenerateColumns="False">
    <DataGrid.Columns>
         <DataGridCheckBoxColumn Binding="{Binding Path=IsChosen, Mode=TwoWay}" Header="Chosen"></DataGridCheckBoxColumn>
         <DataGridTextColumn Binding="{Binding Path=Name, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" Header="Name"></DataGridTextColumn>
         <DataGridTextColumn IsReadOnly="True" Binding="{Binding Path=IsActive, Mode=TwoWay, Converter={StaticResource boolToActive}}" Header="Active"></DataGridTextColumn>
    </DataGrid.Columns>
