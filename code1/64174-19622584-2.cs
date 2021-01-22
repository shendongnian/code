    <!--Users DataGrid-->
    <DataGrid Grid.Row="0" ItemsSource="{Binding DealsUsersViewSource.View}"
		AutoGenerateColumns="False" CanUserAddRows="True" CanUserDeleteRows="False"
		HorizontalAlignment="Stretch" VerticalAlignment="Stretch">
        <DataGrid.Resources>
            <SolidColorBrush x:Key="{x:Static SystemColors.InactiveSelectionHighlightBrushKey}" Color="#FFC5D6FB"/>
        </DataGrid.Resources>
        <DataGrid.Columns>
            
              <!--Username Column-->
              <DataGridComboBoxColumn 
				SelectedValueBinding="{Binding Username}" Header="Username" Width="*">
                  <DataGridComboBoxColumn.ElementStyle>
                      <Style TargetType="{x:Type ComboBox}">
                          <Setter Property="ItemsSource" Value="{Binding DataContext.DealsUsersCollection.ViewModels,
                              RelativeSource={RelativeSource AncestorType={x:Type UserControl}}}" />
                          <Setter Property="SelectedValuePath" Value="Username"/>
                          <Setter Property="DisplayMemberPath" Value="Username"/>
                      </Style>
                  </DataGridComboBoxColumn.ElementStyle>
                  <DataGridComboBoxColumn.EditingElementStyle>
                      <Style TargetType="{x:Type ComboBox}">
                          <Setter Property="ItemsSource" Value="{Binding DataContext.BpcsUsers,
                              RelativeSource={RelativeSource AncestorType={x:Type UserControl}}}" />
                          <Setter Property="SelectedValuePath" Value="Description"/>
                          <Setter Property="DisplayMemberPath" Value="Description"/>
                          <Setter Property="IsEditable" Value="True"/>
                      </Style>
                  </DataGridComboBoxColumn.EditingElementStyle>
              </DataGridComboBoxColumn>
              <!--Supervisor Column-->
              <DataGridComboBoxColumn 
				SelectedValueBinding="{Binding Supervisor}" Header="Supervisor" Width="*">
                  <DataGridComboBoxColumn.ElementStyle>
                      <Style TargetType="{x:Type ComboBox}">
                          <Setter Property="ItemsSource" Value="{Binding DataContext.DealsUsersCollection.ViewModels,
                              RelativeSource={RelativeSource AncestorType={x:Type UserControl}}}" />
                          <Setter Property="SelectedValuePath" Value="Username"/>
                          <Setter Property="DisplayMemberPath" Value="Username"/>
                      </Style>
                  </DataGridComboBoxColumn.ElementStyle>
                  <DataGridComboBoxColumn.EditingElementStyle>
                      <Style TargetType="{x:Type ComboBox}">
                          <Setter Property="ItemsSource" Value="{Binding DataContext.BpcsUsers,
                              RelativeSource={RelativeSource AncestorType={x:Type UserControl}}}" />
                          <Setter Property="SelectedValuePath" Value="Description"/>
                          <Setter Property="DisplayMemberPath" Value="Description"/>
                          <Setter Property="IsEditable" Value="True"/>
                      </Style>
                  </DataGridComboBoxColumn.EditingElementStyle>
              </DataGridComboBoxColumn>
              <!--Plan Moderator Column-->
              <DataGridCheckBoxColumn Binding="{Binding IsPlanModerator}" Header="Plan Moderator?" Width="*"/>
              <!--Planner Column-->
              <DataGridCheckBoxColumn Binding="{Binding IsPlanner}" Header="Planner?" Width="*"/>
        
        </DataGrid.Columns>
    </DataGrid>
