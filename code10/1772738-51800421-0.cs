    <DataGrid Name="dgRowDetails" Background="Transparent" Foreground="Black" SelectionMode="Single" HeadersVisibility="Column"
            ItemsSource="{Binding Games[0].Players}">
    <DataGrid.Resources>
    <Style x:Key="DataGridComboBoxColumnStyle0" BasedOn="{StaticResource BaseComboBoxBoxStyle}" TargetType="ComboBox">
        <Setter Property="ItemsSource" Value="{Binding AllSelectionStatus, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}" />
        <Setter Property="SelectedItem" Value="{Binding PlayerSelectionStatus, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
        <Setter Property="IsSynchronizedWithCurrentItem" Value="False"/>
        <Style.Triggers>
        <DataTrigger Binding="{Binding IsVisible}" Value="False">
            <Setter Property="Visibility" Value="Collapsed" />
    
        </DataTrigger>
        <DataTrigger Binding="{Binding IsSystemEnabled}" Value="False">
            <Setter Property="IsEnabled" Value="False" />
        </DataTrigger>
        </Style.Triggers>
    </Style>
    
    <Style x:Key="DataGridComboBoxColumnStyle1" BasedOn="{StaticResource BaseComboBoxBoxStyle}" TargetType="ComboBox">
        <Setter Property="ItemsSource" Value="{Binding AllSelectionStatus,  Mode=OneWay, UpdateSourceTrigger=PropertyChanged}" />
        <Setter Property="SelectedItem" Value="{Binding PlayerSelectionStatus, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
        <Setter Property="IsSynchronizedWithCurrentItem" Value="False"/>
        <Style.Triggers>
        <DataTrigger Binding="{Binding IsVisible}" Value="False">
            <Setter Property="Visibility" Value="Collapsed" />
        </DataTrigger>
        <DataTrigger Binding="{Binding IsSystemEnabled}" Value="False">
            <Setter Property="IsEnabled" Value="False" />
        </DataTrigger>
        </Style.Triggers>
    <!-- The 3rd Combobox style not shown as it is similar to the one above-->
    </Style>    
