    <ListBox>
    <ListBox.ItemContainerStyle>
        <Style TargetType="ListBoxItem">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type ListBoxItem}">
                        <ControlTemplate.Resources>
                            <Storyboard x:Key="BorderAnimationToRed">
                                <ColorAnimation Storyboard.TargetName="Border" Storyboard.TargetProperty="Background.Color" To="Red" Duration="0:0:0.1" />
                            </Storyboard>
                            <Storyboard x:Key="BorderAnimationToBlue">
                                <ColorAnimation Storyboard.TargetName="Border" Storyboard.TargetProperty="Background.Color" To="Blue" Duration="0:0:0.1" />
                            </Storyboard>
                            <Storyboard x:Key="BorderAnimationToOrange">
                                <ColorAnimation Storyboard.TargetName="Border" Storyboard.TargetProperty="Background.Color" To="Orange" Duration="0:0:0.1" />
                            </Storyboard>
                            <Storyboard x:Key="BorderAnimationToWhite">
                                <ColorAnimation Storyboard.TargetName="Border" Storyboard.TargetProperty="Background.Color" To="White" Duration="0:0:0.1" />
                            </Storyboard>
                        </ControlTemplate.Resources>
                        <Border Name="Border" BorderBrush="DarkGray" BorderThickness="1" Margin="3">
                            <ContentPresenter />
                            <Border.Background>
                                <SolidColorBrush />
                            </Border.Background>
                        </Border>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsMouseOver" Value="True">
                                <Trigger.EnterActions>
                                    <BeginStoryboard Storyboard="{StaticResource BorderAnimationToOrange}"/>
                                </Trigger.EnterActions>
                                <Trigger.ExitActions>
                                    <BeginStoryboard Storyboard="{StaticResource BorderAnimationToWhite}"/>
                                </Trigger.ExitActions>
                            </Trigger>
                            <Trigger Property="IsSelected" Value="True">
                                <Trigger.EnterActions>
                                    <BeginStoryboard Storyboard="{StaticResource BorderAnimationToBlue}"/>
                                </Trigger.EnterActions>
                                <Trigger.ExitActions>
                                    <BeginStoryboard Storyboard="{StaticResource BorderAnimationToWhite}"/>
                                </Trigger.ExitActions>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </ListBox.ItemContainerStyle>
    <ListBox.Items>
        <sys:String>hey</sys:String>
        <sys:String>du</sys:String>
        <sys:String>dux</sys:String>
        <sys:String>duy</sys:String>
        <sys:String>dua</sys:String>
    </ListBox.Items>
