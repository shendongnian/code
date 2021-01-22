    <DataTemplate DataType="{x:Type local:Week}">
      <ItemsControl ItemSource={Binding Days}>
        <ItemsControl.ItemsPanel>
          <ItemsPanelTemplate>
            <Grid>
              <Grid.ColumnDefinitions>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="*"/>
              </Grid.ColumnDefinitions>
            </Grid>
          </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
      </ItemsControl>
    </DataTemplate>
