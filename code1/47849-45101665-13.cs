    <ResourceDictionary ... >
        <Style TargetType="{x:Type local:Viewer}"
               BasedOn="{StaticResource {x:Type ContentControl}}">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type local:Viewer}">
                        <!-- Container -->
                        <Border
                            Width="{TemplateBinding Width}"
                            Height="{TemplateBinding Height}"
                            Background="{TemplateBinding Background}"
                            BorderBrush="{TemplateBinding BorderBrush}"
                            BorderThickness="{TemplateBinding BorderThickness}"
                            Cursor="{TemplateBinding Cursor}">
                            <Grid ClipToBounds="True">
                            
                                <!-- Viewbox -->
                                <Viewbox>
                                    <!-- Content -->
                                    <ContentPresenter
                                        Content="{TemplateBinding Content}"
                                        ContentTemplate="{TemplateBinding ContentTemplate}" />
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
                            </Grid>
                        </Border>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </ResourceDictionary>
