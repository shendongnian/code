    <Window.DataContext>
        <local:ViewModel/>
    </Window.DataContext>
    ...
        <StackPanel>
            <CheckBox Name="CheckBox" IsChecked="{Binding IsChecked, Mode=TwoWay}"/>
            <TextBlock Text="Your text here">
                <TextBlock.InputBindings>
                    <MouseBinding Command="{Binding IsCheckedCommand}" MouseAction="LeftClick" />
                </TextBlock.InputBindings>
            </TextBlock>
        </StackPanel>
