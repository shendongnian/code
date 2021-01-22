    <ListView .. >
     <ListView.Resources>
      <BooleanToVisibilityConverter x:Key="boolToVis" />
     </ListView.Resources>
    
     <ListView.View>
        <GridView>
            <GridViewColumn Header="Test" IsVisible="{Binding Path=ColumnIsVisible, Converter={StaticResource boolToVis}}" />
        </GridView>
     <ListView.View>
