    <Button Content="SomeButton">
        <Button.Style>
            <Style TargetType="Button">
                <Setter Property="IsEnabled" Value="True" />
                <Style.Triggers>
                    <DataTrigger Binding="{Binding myObservableCollection.Count}" Value="0">
                        <Setter Property="IsEnabled" Value="False" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Button.Style>
    </Button>
