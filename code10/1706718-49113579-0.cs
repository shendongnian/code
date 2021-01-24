    <TabControl>
        <TabControl.Resources>
            <Style TargetType="TabItem">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="TabItem">
                            <Border Name="Border" BorderThickness="1,1,1,0" Margin="2,0,2,0">
                                <ContentPresenter ContentSource="Header"/>
                            </Border>
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsMouseOver" Value="True">
                                    <Setter TargetName="Border" Property="Cursor" Value="Hand" />
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
            <DataTemplate x:Key="HeaderTemplate">
                <TextBlock Margin="5,2,5,2" TextAlignment="Center" Text="{Binding}">
                    <TextBlock.Style>
                        <Style TargetType="TextBlock">
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding IsMouseOver, RelativeSource={RelativeSource AncestorType=TabItem}}" Value="True">
                                    <Setter Property="FontWeight" Value="Bold" />
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </TextBlock.Style>
                </TextBlock>
            </DataTemplate>
        </TabControl.Resources>
        <TabItem Header="London" HeaderTemplate="{StaticResource HeaderTemplate}">
        </TabItem>
        <TabItem Header="Paris" HeaderTemplate="{StaticResource HeaderTemplate}">
        </TabItem>
        <TabItem Header="Tokyo" HeaderTemplate="{StaticResource HeaderTemplate}">
        </TabItem>
    </TabControl>
