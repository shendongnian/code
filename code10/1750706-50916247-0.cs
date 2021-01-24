    <Expander IsExpanded="{Binding Path=IsExpanded, Mode=TwoWay}" 
              Header="Click to expand">
      <HeaderedContentControl.HeaderTemplate>
        <DataTemplate>
            <StackPanel>
                <Label Background="Green" Content="{Binding}"/>
            </StackPanel>
        </DataTemplate>
      </HeaderedContentControl.HeaderTemplate>
    </Expander>
