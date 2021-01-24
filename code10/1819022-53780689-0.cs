    <TreeView x:Name="TheTreeView">                  
      <TreeView.ItemTemplate>
                    <HierarchicalDataTemplate ItemsSource="{Binding ListOfItemType_2 }" DataType="{x:Type local:ItemType_1ViewModel}">
                        <rxui:ViewModelViewHost ViewModel="{Binding}"/>
                        <HierarchicalDataTemplate.ItemTemplate>
                            <HierarchicalDataTemplate DataType="{x:Type local:ItemType_2ViewModel }" >
                                <rxui:ViewModelViewHost ViewModel="{Binding}"/>
                            </HierarchicalDataTemplate>
                        </HierarchicalDataTemplate.ItemTemplate>
                    </HierarchicalDataTemplate>
                </TreeView.ItemTemplate>
            </TreeView>
