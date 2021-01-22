    ' ItemVM...
    Public Property IsSelected As Boolean
        Get
            Return _func.SelectedNode Is Me
        End Get
        Set(value As Boolean)
            If IsSelected <> value Then
                _func.SelectedNode = If(value, Me, Nothing)
            End If
            RaisePropertyChange()
        End Set
    End Property
    ' TreeVM...
    Public Property SelectedItem As ItemVM
        Get
            Return _selectedItem
        End Get
        Set(value As ItemVM)
            If _selectedItem Is value Then
                Return
            End If
            Dim prev = _selectedItem
            _selectedItem = value
            If prev IsNot Nothing Then
                prev.IsSelected = False
            End If
            If _selectedItem IsNot Nothing Then
                _selectedItem.IsSelected = True
            End If
        End Set
    End Property
    <TreeView ItemsSource="{Binding Path=TreeVM}" 
              BorderBrush="Transparent">
        <TreeView.ItemContainerStyle>
            <Style TargetType="TreeViewItem">
                <Setter Property="IsExpanded" Value="{Binding IsExpanded}"/>
                <Setter Property="IsSelected" Value="{Binding IsSelected, Mode=TwoWay}"/>
            </Style>
        </TreeView.ItemContainerStyle>
        <TreeView.ItemTemplate>
            <HierarchicalDataTemplate ItemsSource="{Binding Children}">
                <TextBlock Text="{Binding Name}"/>
            </HierarchicalDataTemplate>
        </TreeView.ItemTemplate>
    </TreeView>
