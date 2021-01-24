    <ControlTemplate x:Key="botonProducto" TargetType="{x:Type Button}">
            <Grid Margin="20">
                <Viewbox>
                    <Grid MinHeight="50" MinWidth="50">
                        <Ellipse x:Name="outerCircle"  Fill="Black"/>
                        <Ellipse x:Name="inCircle" Margin="5">
                            <Ellipse.Fill>
                                <ImageBrush ImageSource="{Binding Path=Tag, RelativeSource={RelativeSource TemplatedParent}}"/>
                            </Ellipse.Fill>
                        </Ellipse>
                    </Grid>
                </Viewbox>
            </Grid>
            <ControlTemplate.Triggers>
                <Trigger Property="Button.IsPressed" Value="True">
                    <Setter Property="RenderTransform">
                        <Setter.Value>
                            <ScaleTransform ScaleX=".9" ScaleY=".9"/>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="RenderTransformOrigin" Value=".5,.5"/>
                </Trigger>
            </ControlTemplate.Triggers>
        </ControlTemplate>
