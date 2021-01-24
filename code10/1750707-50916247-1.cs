    <Expander IsExpanded="{Binding Path=IsExpanded, Mode=TwoWay}" 
              Header="{Binding ComplexObject}">
      <HeaderedContentControl.HeaderTemplate>
        <DataTemplate>
            <StackPanel>
                <Label Background="Green" Content="{Binding PropertyOfTheObject}"/>
            </StackPanel>
        </DataTemplate>
      </HeaderedContentControl.HeaderTemplate>
    </Expander>
