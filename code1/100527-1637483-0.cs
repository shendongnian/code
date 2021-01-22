    <UserControl>
      <UserControl.Resources>
        <ControlTemplate x:Key="MyControlTemplate">
             <TextBlock
                Text="{Binding Path=Entity.Quantita}"/>
        </ControlTemplate>
      </UserControl.Resources>
      ...
      <GridViewColumn 
         x:Name="lvCol3"
         Header="Quantità"
         Width="120">
            <GridViewColumn.CellTemplate>
                <DataTemplate>
                   <Control x:Name="host" Template="{StaticResouce MyControlTemplate}">   
                   </Control>
            </GridViewColumn.CellTemplate>
       </GridViewColumn>
      ...
    </UserControl>
