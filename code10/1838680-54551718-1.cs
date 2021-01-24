    <Style x:Key="RoundedLabelStyle" TargetType="{x:Type Label}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="Label">
                            <Grid Height="Auto" Width="Auto" HorizontalAlignment="{TemplateBinding HorizontalAlignment}" VerticalAlignment="{TemplateBinding VerticalAlignment}">
                                <Ellipse x:Name="cp" Margin="0,0,0,0" Fill="{TemplateBinding Background}" Height="{TemplateBinding Width}" Width="{TemplateBinding Width}" Stroke="Black" StrokeThickness="2" />
                                <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center">
                                    <ContentPresenter.Content>
                                        <Border Padding="10">
                                            <StackPanel>
                                                <ContentPresenter Content="{TemplateBinding Content}"/>
                                                <ContentPresenter Content="{TemplateBinding Tag}"/>
                                                <ContentPresenter Content="{TemplateBinding local:LabelExtension.SecondContent}"/>
                                            </StackPanel>
                                        </Border>
                                    </ContentPresenter.Content>
                                </ContentPresenter>
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
