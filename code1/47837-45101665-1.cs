    <ResourceDictionary ... >
        <Style TargetType="{x:Type local:ImageViewer}"
               BasedOn="{StaticResource {x:Type ContentControl}}">
            <Setter Property="Background" Value="white" />
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type local:ImageViewer}">
                        <!-- Container -->
                        <Border
                            Width="{TemplateBinding Width}"
                            Height="{TemplateBinding Height}"
                            Background="{TemplateBinding Background}"
                            BorderBrush="{TemplateBinding BorderBrush}"
                            BorderThickness="{TemplateBinding BorderThickness}"
                            ClipToBounds="True"
                            Cursor="{TemplateBinding Cursor}">
                            <!-- Viewbox -->
                            <Viewbox>
                                <Grid>
                                    <!-- Image -->
                                    <Image
                                        Source="{TemplateBinding Image}"
                                        Margin="{TemplateBinding Padding}"/>
                                </Grid>
                                <!-- Render Transform -->
                                <Viewbox.RenderTransform>
                                    <TransformGroup>
                                        <ScaleTransform
                                            ScaleX="{Binding Zoom, RelativeSource={RelativeSource TemplatedParent}}"
                                            ScaleY="{Binding Zoom, RelativeSource={RelativeSource TemplatedParent}}" />
                                        <TranslateTransform
                                            X="{Binding Translate.X, RelativeSource={RelativeSource TemplatedParent}}"
                                            Y="{Binding Translate.Y, RelativeSource={RelativeSource TemplatedParent}}" />
                                    </TransformGroup>
                                </Viewbox.RenderTransform>
                            </Viewbox>
                        </Border>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </ResourceDictionary>
