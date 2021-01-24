           <Menu.Resources>
                <Style TargetType="{x:Type MenuItem}">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="{x:Type MenuItem}">
                                <Border Background="{TemplateBinding Background}">
                                    <ContentPresenter Content="{TemplateBinding Header}"/>
                                </Border>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </Menu.Resources>
