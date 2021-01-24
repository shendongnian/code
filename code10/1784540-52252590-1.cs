    <ControlTemplate TargetType="ProgressBar">
        <ControlTemplate.Triggers>
            <Trigger Property="Value" Value="100">
                <Setter TargetName="PART_Indicator" Property="RenderTransform" Value="{x:Null}"/>
            </Trigger>
        </ControlTemplate.Triggers>
        <Border BorderBrush="#D9DCE1" BorderThickness="0" Background="#FF0C0B0B" CornerRadius="0" Padding="0">
            <Grid x:Name="PART_Track" ClipToBounds="True">
                <Rectangle x:Name="PART_Indicator" HorizontalAlignment="Left" Fill="#FF2BA9FF" RenderTransformOrigin="0,0">
                    <Rectangle.RenderTransform>
                        <SkewTransform AngleX="-45"/>
                    </Rectangle.RenderTransform>
                </Rectangle>
            </Grid>
        </Border>
    </ControlTemplate>
