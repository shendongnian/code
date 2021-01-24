    <Canvas>
        <ItemsControl Name="btnTableImageList">
            <ItemsControl.ItemsPanel>
                <DataTemplate>
                    <Canvas/>
                </DataTemplate>
           </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Label Content="Label"
                           Background="ForestGreen"
                           Padding="12,7"
                           Canvas.Left="{Binding XPosition}"
                           Canvas.Top="{Binding YPosition}"
                           MouseDown="Label_MouseDown"
                           MouseUp="Label_MouseUp"
                           MouseMove="Label_MouseMove"/>
                </DataTemplate>
           </ItemsControl.ItemTemplate>
        </ItemsControl>
    </Canvas>
