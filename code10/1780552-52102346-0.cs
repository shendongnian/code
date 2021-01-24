    <DataGrid ItemsSource="{Binding ModelRevisionList}" AutoGenerateColumns="False">
         <DataGrid.Columns>
              <DataGridTextColumn Header="Date" Binding="{Binding Date}"/>
              <DataGridTextColumn Header="Edited By" Binding="{Binding EditedBy}"/>
              <DataGridTextColumn Header="Description" Binding="{Binding Description}"/>
         </DataGrid.Columns>
    </DataGrid>
