    <ContentControl Content="{Binding}">
        <ContentControl.Style>
            <Style TargetType="{x:Type ContentControl}">
                <!-- The Default/initial View being shown -->
                <Setter Property="ContentTemplate" Value="{StaticResource View1Template}" />
                <!-- Triggers bound to the CurrentView Property -->
                <Style.Triggers>
                    <DataTrigger Binding="{Binding CurrentView}" Value="1">
                        <Setter Property="ContentTemplate" Value="{StaticResource View1Template}" />
                    </DataTrigger>
                    <DataTrigger Binding="{Binding CurrentView}" Value="2">
                        <Setter Property="ContentTemplate" Value="{StaticResource View2Template}" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ContentControl.Style>
    </ContentControl>
