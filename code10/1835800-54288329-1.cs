    <RichTextBox>
        <RichTextBox.Resources>
            <SolidColorBrush x:Key="TextBox.Static.Border" Color="#FFABAdB3"/>
            <SolidColorBrush x:Key="TextBox.MouseOver.Border" Color="#FF7EB4EA"/>
            <SolidColorBrush x:Key="TextBox.Focus.Border" Color="#FF569DE5"/>
        </RichTextBox.Resources>
        <RichTextBox.Template>
            <ControlTemplate TargetType="{x:Type TextBoxBase}">
                <Border x:Name="border" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" SnapsToDevicePixels="True">
                    <local:MyScrollViewer x:Name="PART_ContentHost" Focusable="false" HorizontalScrollBarVisibility="Hidden" VerticalScrollBarVisibility="Hidden"/>
                </Border>
                <ControlTemplate.Triggers>
                    <Trigger Property="IsEnabled" Value="false">
                        <Setter Property="Opacity" TargetName="border" Value="0.56"/>
                    </Trigger>
                    <Trigger Property="IsMouseOver" Value="true">
                        <Setter Property="BorderBrush" TargetName="border" Value="{StaticResource TextBox.MouseOver.Border}"/>
                    </Trigger>
                    <Trigger Property="IsKeyboardFocused" Value="true">
                        <Setter Property="BorderBrush" TargetName="border" Value="{StaticResource TextBox.Focus.Border}"/>
                    </Trigger>
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </RichTextBox.Template>
    </RichTextBox>
