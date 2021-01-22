        <cc:UserControl x:Name="UserControl" ItemsSource="{Binding Path=DataItem}" MouseDoubleClick="UserControl_MouseDoubleClick" >
            <cc:UserControl.ContextMenu>
                <ContextMenu local:ElementSpy.NameScopeSource="{StaticResource ElementSpy}">
                    <MenuItem Header="_Enlarge" Command="{Binding Path=EnlargeCommand}" CommandParameter="{Binding ElementName=UserControl, Path=.}"/>
                    </MenuItem>
                </ContextMenu>
            </cc:UserControl.ContextMenu>
        </cc:UserControl>
