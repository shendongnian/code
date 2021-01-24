    <Application.Resources>
        <ResourceDictionary>
            <ControlTemplate x:Key="CommonTemplate" TargetType="UserControl">
                <Border BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" 
                        Padding="{TemplateBinding Padding}" SnapsToDevicePixels="true">
                    <Grid>
                        <Grid.RowDefinitions>
                            <RowDefinition />
                            <RowDefinition />
                            <RowDefinition />
                            <RowDefinition />
                        </Grid.RowDefinitions>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="Auto" />
                            <ColumnDefinition Width="*" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Text="Label" />
                        <TextBox Grid.Column="1" />
                        <TextBlock Grid.Row="1" Text="Label" />
                        <TextBox Grid.Row="1" Grid.Column="1" />
                        <ContentPresenter Grid.Row="2" Grid.ColumnSpan="2" 
                                            HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" 
                                            SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" 
                                            VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                        <TextBlock Grid.Row="3" Text="Label" />
                        <TextBox Grid.Row="3" Grid.Column="1" />
                    </Grid>
                </Border>
            </ControlTemplate>
        </ResourceDictionary>
    </Application.Resources>
