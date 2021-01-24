    <HierarchicalDataTemplate DataType="root" ItemsSource="{Binding XPath=./*}" >
                <StackPanel Orientation="Horizontal">
                    <TextBlock Margin="0" Text="ROOT"  Tag="{Binding DataContext, ElementName=TestControl}">
                        <TextBlock.ContextMenu>
                            <ContextMenu
                            cal:Action.TargetWithoutContext="{Binding PlacementTarget.Tag, RelativeSource={RelativeSource Self}}">
                                <MenuItem Header="Add Element" cal:Message.Attach="[Event Click] = [Action AddElement($datacontext)]" />
                            </ContextMenu>
                        </TextBlock.ContextMenu>
                        </TextBlock>
                </StackPanel>
            </HierarchicalDataTemplate>
