    <TreeView >
        <TreeView.Style>
            <Style TargetType="TreeView"> 
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="TreeView">
                            <TreeViewList x:Name="ListControl" AllowDrop="True" DragItemsStarting="ListControl_DragItemsStarting" CanReorderItems="True" CanDragItems="True" ItemContainerStyle="{StaticResource TreeViewItemStyle}" ItemTemplate="{StaticResource TreeViewItemDataTemplate}">
                                <TreeViewList.ItemContainerTransitions>
                                    <TransitionCollection>
                                        <ContentThemeTransition/>
                                        <ReorderThemeTransition/>
                                        <EntranceThemeTransition IsStaggeringEnabled="False"/>
                                    </TransitionCollection>
                                </TreeViewList.ItemContainerTransitions>
                            </TreeViewList>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </TreeView.Style> 
        <TreeView.RootNodes>
            <TreeViewNode Content="Flavors" IsExpanded="True" >
                <TreeViewNode.Children>
                    <TreeViewNode Content="Vanilla"/>
                    <TreeViewNode Content="Strawberry"/>
                    <TreeViewNode Content="Chocolate"/>
                </TreeViewNode.Children>
            </TreeViewNode>
        </TreeView.RootNodes>
    </TreeView>
     private void ListControl_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
     {
     }
