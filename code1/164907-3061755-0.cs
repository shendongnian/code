    <ListView ItemsSource="{Binding AllSelections}">
      <ListView.View>
        <GridView>
          
          <!-- First column -->
          <GridViewColumn Header="Title" DisplayMemberBinding="{Binding}">
            <GridViewColumn.CellTemplate>
              <DataTemplate>
                <DataTemplate.Resources>
                  <!-- First column content for ContactModel objects -->                  
                  <DataTemplate DataType="{x:Type local:ContactModel}">
                    <TextBlock Text="{Binding Name}" />
                  </DataTemplate>
                  <!-- First column content for NoteModel objects -->                  
                  <DataTemplate DataType="{x:Type local:NoteModel}">
                    <TextBlock Text="{Binding Title}" />
                  </DataTemplate>
                  
                  ...
                </DataTemplate.Resources>
                <!-- This selects one of the above templates and applies it -->
                <ContentPresenter /> 
              </DataTemplate>
            </GridViewColumn.CellTemplate>
          </GridViewColumn>
          <!-- Second column -->
          <GridViewColumn ...>
            ...
          </GridViewColumn>
          
        </GridView>
      </ListView.View>
    </ListView>
