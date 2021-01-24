    <TreeView.ItemTemplate>
                    <HierarchicalDataTemplate ItemsSource="{Binding Positions}" >
                        <Label Content="{Binding DepartmentName}"/>
                        <HierarchicalDataTemplate.ItemTemplate>
                            <HierarchicalDataTemplate ItemsSource="{Binding Employees}" >
                                <Label Content="{Binding PositionName}"  Tag="{Binding DataContext, ElementName=TestControl}" >
                                    <Label.ContextMenu>
                                        <ContextMenu cal:Action.TargetWithoutContext="{Binding PlacementTarget.Tag, RelativeSource={RelativeSource Self}}">
                                            <MenuItem Header="Add Element" cal:Message.Attach="[Event Click] = [Action AddElement($datacontext)]"/>
                                        </ContextMenu>
                                    </Label.ContextMenu>
                                </Label>
                                <HierarchicalDataTemplate.ItemTemplate>
                                    <DataTemplate>
                                        <Label Content="{Binding EmployeeName}" Tag="{Binding DataContext, ElementName=TestControl}">
                                            <Label.ContextMenu>
                                                <ContextMenu cal:Action.TargetWithoutContext="{Binding PlacementTarget.Tag, RelativeSource={RelativeSource Self}}">
                                                    <MenuItem Header="Add Element" cal:Message.Attach="[Event Click] = [Action AddElement($datacontext)]"
                    />
                                                </ContextMenu>
                                            </Label.ContextMenu>
                                        </Label>
                                    </DataTemplate>
                                </HierarchicalDataTemplate.ItemTemplate>
                            </HierarchicalDataTemplate>
                        </HierarchicalDataTemplate.ItemTemplate>
                    </HierarchicalDataTemplate>
                </TreeView.ItemTemplate>
 
