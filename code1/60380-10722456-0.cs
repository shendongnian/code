    <RadioButton GroupName="myGroup"
                 Style="{StaticResource MenuButton}"
                 Content="One" 
                 IsChecked="True" />
    <RadioButton GroupName="myGroup"
                 Style="{StaticResource MenuButton}"
                 Content="Two" />    
    <RadioButton GroupName="myGroup"
                 Style="{StaticResource MenuButton}"
                 Content="Three" />
    <Style x:Key="MenuButton" TargetType="RadioButton">
        <Setter Property="Width" Value="100"/>
        <Setter Property="Height" Value="25"/>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="RadioButton">
                    <Border BorderBrush="DarkGray" BorderThickness="3" CornerRadius="3" Background="Gray">
                        <ToggleButton IsChecked="{Binding IsChecked, RelativeSource={RelativeSource TemplatedParent}, Mode=TwoWay}">
                            <ToggleButton.Content>                  
                                <ContentPresenter></ContentPresenter>
                            </ToggleButton.Content>
                        </ToggleButton>                              
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
