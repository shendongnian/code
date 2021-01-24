    <Image Source="{Binding Poster}">
        <Image.Style>
            <Style TargetType="Image">
                <Setter Property="Opacity" Value="1"/>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsMouseOver,
                                           RelativeSource={RelativeSource AncestorType=ListBoxItem}}"
                                 Value="True">
                        <Setter Property="Opacity" Value="0.5"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Image.Style>
    </Image>
