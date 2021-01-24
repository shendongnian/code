    <GroupBox>
      <StackPanel Orientation="Vertical">
        <StackPanel.Resources>
             <local:VisibilityInverter x:key="VisInverter"/>
        </StackPanel.Resources>
        <DataGrid x:Name="Dt">
            <DataGrid.Columns>
                <DataGridTextColumn Header="home" />
            </DataGrid.Columns>
        </DataGrid>
        <Label Content="Foo" Visibility="{Binding Path=Visibility, ElementName=Dt, Converter={StaticResource VisInverter}}" />
      </StackPanel>
    </GroupBox>
