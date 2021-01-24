        <Window.DataContext>
            <local:MainWIndowViewModel/>
        </Window.DataContext>
        <Grid>
            <TabControl Name="tc" ItemsSource="{Binding vms}">
                <TabControl.Resources>
                    <DataTemplate DataType="{x:Type local:uc1vm}">
                        <local:UserControl1/>
                    </DataTemplate>
                    <DataTemplate DataType="{x:Type local:uc2vm}">
                        <local:UserControl2/>
                    </DataTemplate>
                </TabControl.Resources>
                <TabControl.ItemContainerStyle>
                    <Style TargetType="TabItem">
                        <Setter Property="Header" Value="{Binding TabHeading}"/>
                    </Style>
                </TabControl.ItemContainerStyle>
            </TabControl>
        </Grid>
    </Window>
