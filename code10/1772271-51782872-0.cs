    <ListView x:Name="MovieListView" Margin="30,0,50,48" Height="344" VerticalAlignment="Bottom">
        <ListView.ItemContainerStyle>
            <Style TargetType="{x:Type ListViewItem}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type ListViewItem}">
                            <Border x:Name="Bd" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" Padding="{TemplateBinding Padding}" SnapsToDevicePixels="true">
                                <ContentPresenter HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                            </Border>
                            <ControlTemplate.Triggers>
                                <MultiTrigger>
                                    <MultiTrigger.Conditions>
                                        <Condition Property="IsMouseOver" Value="True"/>
                                    </MultiTrigger.Conditions>
                                    <Setter Property="Background" TargetName="Bd" Value="#1F26A0DA"/>
                                    <Setter Property="BorderBrush" TargetName="Bd" Value="#a826A0Da"/>
                                </MultiTrigger>
                                <MultiTrigger>
                                    <MultiTrigger.Conditions>
                                        <Condition Property="Selector.IsSelectionActive" Value="False"/>
                                        <Condition Property="IsSelected" Value="True"/>
                                    </MultiTrigger.Conditions>
                                    <Setter Property="Background" TargetName="Bd" Value="#3DDADADA"/>
                                    <Setter Property="BorderBrush" TargetName="Bd" Value="#FFDADADA"/>
                                </MultiTrigger>
                                <MultiTrigger>
                                    <MultiTrigger.Conditions>
                                        <Condition Property="Selector.IsSelectionActive" Value="True"/>
                                        <Condition Property="IsSelected" Value="True"/>
                                    </MultiTrigger.Conditions>
                                    <Setter Property="Background" TargetName="Bd" Value="Red"/>
                                    <Setter Property="BorderBrush" TargetName="Bd" Value="#FF26A0DA"/>
                                </MultiTrigger>
                                <Trigger Property="IsEnabled" Value="False">
                                    <Setter Property="TextElement.Foreground" TargetName="Bd" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}"/>
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </ListView.ItemContainerStyle>
        <ListView.ItemTemplate>
            <DataTemplate>
                <StackPanel>
                    <TextBlock Text="{Binding Path= MovieID}" />
                    <TextBlock Text="{Binding Path= MovieName}" FontWeight="Bold" />
                </StackPanel>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
