    <Style.Triggers>
        <MultiDataTrigger>
            <MultiDataTrigger.Conditions>
                <Condition Binding="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type ListViewItem}}, Converter={StaticResource GetRowIndexConverter}}" Value="0" />
                <Condition Binding="{Binding AddStatus}" Value="Visible" />
            </MultiDataTrigger.Conditions>
            <MultiDataTrigger.Setters>
                <Setter Property="IsReadOnly" Value="True" />
            </MultiDataTrigger.Setters>
        </MultiDataTrigger>
    </Style.Triggers>
