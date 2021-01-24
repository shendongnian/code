    <Grid.Resources>
              <Style x:Key="hover2" TargetType="Button">
                  <Setter Property="OverridesDefaultStyle" Value="True"/>
                  <Setter Property="Template">
                      <Setter.Value>
                          <ControlTemplate TargetType="Button">
                                <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center">
                                    <ContentPresenter.Content>
                                        <Border Name="border" 
                                              BorderThickness="0"                         
                                              BorderBrush="Transparent"                          
                                              Background="{TemplateBinding Background}">
                                            <Image x:Name="ButtonImage1" Source="Resources/copyPaste.png" Height="17" Width="17" />
                                        </Border>
                                    </ContentPresenter.Content>
                                </ContentPresenter>
                                <ControlTemplate.Triggers>
                                  <Trigger Property="IsMouseOver" Value="True">
                                      <Setter TargetName="border" Property="BorderBrush" Value="Black" />
                                        <Setter TargetName="ButtonImage1" Property="Source" Value="Resources/hoverImage.png" />
                                    </Trigger>
                              </ControlTemplate.Triggers>
                          </ControlTemplate>
                      </Setter.Value>
                  </Setter>
              </Style>
            </Grid.Resources>
