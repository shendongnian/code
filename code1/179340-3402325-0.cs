    <TreeView.Resources>
        <Style TargetType="TreeViewItem">
            <Setter Property="IsExpanded" Value="{Binding Path=IsExpanded, Mode=TwoWay}" />
            <Setter Property="IsSelected" Value="{Binding Path=IsSelected, Mode=TwoWay}" />
            <EventSetter Event="TreeViewItem.MouseRightButtonDown" Handler="tvw_MouseRightButtonUp"/>
        </Style>
        <HierarchicalDataTemplate DataType="{x:Type vm:ViewModel}" ItemsSource="{Binding Children}">
            <TextBlock Name="TextBlock" Text="{Binding Caption}"/>
            <HierarchicalDataTemplate.Triggers>
                <DataTrigger Binding="{Binding IsDeleted}" Value="True">
                    <Setter TargetName="TextBlock" Property="TextDecorations" Value="Underline" />
                </DataTrigger>
            </HierarchicalDataTemplate.Triggers>
        </HierarchicalDataTemplate>
    </TreeView.Resources>
