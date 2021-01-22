    <Page xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
        <Page.Resources>
            <DataTemplate x:Key="TaskListTemplate">
                <Border MinWidth="50" Height="70" Background="{TemplateBinding ListBoxItem.Background}" BorderBrush="Black" CornerRadius="8" Margin="0">
                    <Grid Background="Transparent">
                        <TextBox x:Name="txtDescription" Text="{Binding Path=Des}" Background="Transparent"/>
                        <TextBox x:Name="txtComments" Text="{Binding Path=Com}" Background="Transparent"/>
                        <Label Content="{Binding Path=Title}" Background="Transparent"/>
                    </Grid>
                </Border>
            </DataTemplate>
            <Style x:Key="ListBoxItemStyle" TargetType="{x:Type ListBoxItem}">
                <Setter Property="FontSize" Value="12"/>
                <Setter Property="FontFamily" Value="Tahoma"/>
                <Setter Property="Background" Value="#006C3B3B"/>
                <Setter Property="ContentTemplate" Value="{DynamicResource TaskListTemplate}"/>
                <Style.Resources>
                    <SolidColorBrush x:Key="{x:Static SystemColors.HighlightBrushKey}" Color="#FF533F70"/>
                    <SolidColorBrush x:Key="{x:Static SystemColors.ControlBrushKey}" Color="#FF533F70"/>
                    <Storyboard x:Key="MouseOverStoryBoard">
                        <ColorAnimationUsingKeyFrames AutoReverse="True" BeginTime="00:00:00" Storyboard.TargetName="{x:Null}" Storyboard.TargetProperty="(Panel.Background).(SolidColorBrush.Color)">
                            <SplineColorKeyFrame KeyTime="00:00:00" Value="#FFF48F21"/>
                            <SplineColorKeyFrame KeyTime="00:00:00.500" Value="#FF4A475C"/>
                        </ColorAnimationUsingKeyFrames>
                    </Storyboard>
                </Style.Resources>
                <Style.Triggers>
                    <Trigger Property="ItemsControl.AlternationIndex" Value="0">
                        <Setter Property="Background">
                            <Setter.Value>
                                <SolidColorBrush Color="#FFA2BAD4"/>
                            </Setter.Value>
                        </Setter>
                        <Setter Property="Foreground" Value="White"/>
                    </Trigger>
                    <Trigger Property="ItemsControl.AlternationIndex" Value="1">
                        <Setter Property="Background" Value="#FF7395B9"/>
                        <Setter Property="Foreground" Value="White"/>
                    </Trigger>
                    <Trigger Property="IsMouseOver" Value="True">
                        <Trigger.EnterActions>
                            <BeginStoryboard Storyboard="{StaticResource MouseOverStoryBoard}"/>
                        </Trigger.EnterActions>
                        <Setter Property="Foreground" Value="White"/>
                        <Setter Property="Background" Value="#FFF48F21"/>
                        <Setter Property="FontStyle" Value="Normal"/>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </Page.Resources>
        <Grid>
            <ListBox Margin="8,37,0,6" 
                     ItemContainerStyle="{DynamicResource ListBoxItemStyle}" 
                     AlternationCount="2">
                <ListBoxItem>Test1</ListBoxItem>
                <ListBoxItem>Test2</ListBoxItem>
                <ListBoxItem>Test3</ListBoxItem>
            </ListBox>
        </Grid>
    </Page>
