    <Window.Resources>
        <Style TargetType="ContentControl" x:Key="BaseStyle">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="ContentControl">
                        <Border Background="{TemplateBinding Background}"
                                BorderBrush="{TemplateBinding BorderBrush}"
                                BorderThickness="{TemplateBinding BorderThickness}">
                            <Path x:Name="path" Stroke="{TemplateBinding Foreground}"
                                  Data="{TemplateBinding Content}" Stretch="Fill"/>
                        </Border>
                        <ControlTemplate.Triggers>
                            <DataTrigger Binding="{Binding Path=Status}" Value="0">
                                <Setter TargetName="path"
                                        Property="Visibility" Value="Hidden"/>
                            </DataTrigger>
                            <DataTrigger Binding="{Binding Path=Status}" Value="1">
                                <Setter TargetName="path"
                                        Property="Visibility" Value="Hidden"/>
                            </DataTrigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
            <Setter Property="Background" Value="Black"/>
            <Setter Property="BorderBrush" Value="{Binding Foreground,
                                            RelativeSource={RelativeSource Self}}"/>
            <Setter Property="BorderThickness" Value="1"/>
            <Setter Property="Width" Value="20"/>
            <Setter Property="Height" Value="20"/>
        </Style>
        <Style x:Key="230KV" TargetType="ContentControl" BasedOn="{StaticResource BaseStyle}">
            <Setter Property="Foreground" Value="Red"/>
        </Style>
        <Style x:Key="132KV" TargetType="ContentControl" BasedOn="{StaticResource BaseStyle}">
            <Setter Property="Foreground" Value="Green"/>
        </Style>
        <Style x:Key="400KV" TargetType="ContentControl" BasedOn="{StaticResource BaseStyle}">
            <Setter Property="Foreground" Value="Purple"/>
        </Style>
    </Window.Resources>
    <StackPanel>
        <ContentControl Style="{StaticResource 230KV}">
            <PathGeometry>M0,0 L1,1 M0,1 L1,0</PathGeometry>
        </ContentControl>
        <ContentControl Style="{StaticResource 132KV}">
            <PathGeometry>M0,0 L1,1 M0,1 L1,0</PathGeometry>
        </ContentControl>
        <ContentControl Style="{StaticResource 400KV}">
            <PathGeometry>M0,0 L1,1 M0,1 L1,0</PathGeometry>
        </ContentControl>
    </StackPanel>
