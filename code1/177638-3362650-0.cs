        <TabControl>
            <TabControl.Resources>
                <Style TargetType="{x:Type TextBlock}">
                    <Setter Property="FontFamily" Value="Comic Sans MS" />
                    <Setter Property="FontSize" Value="20" />
                </Style>
                <Style x:Key="headerStyle" TargetType="{x:Type TextBlock}">
                    <Setter Property="Control.FontFamily" Value="Papyrus" />
                    <Setter Property="Control.FontSize" Value="12" />
                </Style>
            </TabControl.Resources>
            <TabItem>
                <TabItem.Header>
                    <TextBlock Text="Header" Style="{StaticResource headerStyle}" />
                </TabItem.Header>
                <TextBlock Text="Here is the content" />
            </TabItem>
        </TabControl>
