    <Expander Name="pExpander" IsExpanded="True" Header="Preview">
        <i:Interaction.Triggers>
            <ei:PropertyChangedTrigger Binding="{Binding ShowPreview, Mode=OneWay}">
                <ei:ChangePropertyAction PropertyName="IsExpanded" Value="{Binding ShowPreview, Mode=OneWay}"/>
            </ei:PropertyChangedTrigger>
        </i:Interaction.Triggers>
        <TextBlock Text="{Binding Path=Message, Mode=OneWay}"></TextBlock>    
    </Expander>
    <Expander Name="pExpander1" IsExpanded="True" Header="Preview 1">
        <i:Interaction.Triggers>
            <ei:PropertyChangedTrigger Binding="{Binding ShowPreview, Mode=OneWay}">
                <ei:ChangePropertyAction PropertyName="IsExpanded" Value="{Binding ShowPreview, Mode=OneWay}"/>
            </ei:PropertyChangedTrigger>
        </i:Interaction.Triggers>
        <TextBlock Text="{Binding Path=Message1, Mode=OneWay}"></TextBlock>    
    </Expander>
    //...
