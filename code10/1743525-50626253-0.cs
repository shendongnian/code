    <!-- 
    Better to define this in one place. 
    I'd do the same with the border color that you use everywhere. 
    -->
    <SolidColorBrush x:Key="ComboBackgroundBrush" Color="#EAEAEA" />
    <Style x:Key="ComboBoxTextBoxStyle" TargetType="{x:Type TextBox}">
        <Style.Triggers>
            <Trigger Property="IsMouseOver" Value="true">
                <Setter Property="Background" Value="Red" />
            </Trigger>
        </Style.Triggers>
        <!-- 
        Must set this in a setter, not an an attribute on the control instance.
        The attribute you had will override anything the style does. This is part of 
        "dependency property value precedence". 
        -->
        <Setter Property="Background" Value="{StaticResource ComboBackgroundBrush}" />
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type TextBox}">
                    <Grid>
                        <Border CornerRadius="2,0,0,2"
                                BorderThickness="1,1,0,1"
                                Background="{TemplateBinding Background}"
                                BorderBrush="#A0A1A2"
                                >
                            <ScrollViewer x:Name="PART_ContentHost"/>
                        </Border>
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
    <Style x:Key="ComboBoxButtonStyle" TargetType="{x:Type ToggleButton}">
        <Style.Triggers>
            <Trigger Property="IsMouseOver" Value="true">
                <Setter Property="Background" Value="Red" />
            </Trigger>
        </Style.Triggers>
        <Setter Property="Background" Value="{StaticResource ComboBackgroundBrush}" />
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type ToggleButton}">
                    <!-- 
                    Needs {TemplateBinding Background} so it uses whatever background brush 
                    the setters apply at any given moment. 
                    -->
                    <Border Background="{TemplateBinding Background}" 
                            x:Name="border" 
                            CornerRadius="0,2,2,0" 
                            BorderThickness="0,1,1,1"
                            BorderBrush="#A0A1A2">
                        <ContentPresenter />
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
    <Style x:Key="RoundComboBox" TargetType="{x:Type ComboBox}" BasedOn="{StaticResource BorderStyle}">
        <Setter Property="HorizontalContentAlignment" Value="Left"/>
        <Setter Property="VerticalContentAlignment" Value="Center"/>
        <Setter Property="FontSize" Value="14px"/>
        <Setter Property="IsReadOnly" Value="True"/>
        <Setter Property="Height" Value="25"/>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type ComboBox}">
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition/>
                            <ColumnDefinition MaxWidth="18"/>
                        </Grid.ColumnDefinitions>
                        <!--
                        Two problems: 
                            1. IsHitTestVisible="False" prevented it from getting any mouse messages.
                            2. Background attribute was overriding anything the Style did,
                               so even if the trigger had fired, its setter would have failed. 
                        Also, Height="{TemplateBinding Height}" is unnecessary. It'll size to its parent Grid.
                        And BorderBrush="#A0A1A2" should probably be in the Style
                        -->
                        <TextBox Name="PART_EditableTextBox"
                                 Padding="0,0,0,0"
                                 BorderBrush="#A0A1A2"
                                 Style="{StaticResource ComboBoxTextBoxStyle}"
                                 />
