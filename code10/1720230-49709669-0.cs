    <Button IsEnabled="{Binding Path=HasItems, ElementName=myDataGrid}">
        <Button.Style>
            <Style TargetType="Button">
                <Style.Triggers>
                    <Trigger property="IsEnabled" Value="False">
                        <Setter Property="Opacity" Value=".5" />
                    </Trigger>
                </Style.Triggers>
           </Style>
       </Button.Style>
    </Button>
