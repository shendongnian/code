    <Style TargetType="Expander">
        <Setter Property="Header">
            <Setter.Value>
                <TextBlock>
                    <TextBlock.Style>
                        <Style TargetType="TextBlock">
                            <Setter Property="Text" Value="{Binding ElementName=This, Path=Presenter.Walls.Count, StringFormat='Walls:  [{0}]'}}" />
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding IsExpanded, RelativeSource={RelativeSource AncestorType=Expander}}" Value="True">
                                    <Setter Property="Text" Value="{Binding Path=Presenter.Walls.Count, StringFormat='Walls  [{0}]'}, RelativeSource={RelativeSource AncestorType=UserControl}}" />
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </TextBlock.Style>
                </TextBlock>
            </Setter.Value>
        </Setter>
    </Style>
