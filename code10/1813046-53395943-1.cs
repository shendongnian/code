         <Setter.Value>
                    <ControlTemplate TargetType="{x:Type MenuItem}">
                        <Grid>
                            <Border x:Name="border" Background="{TemplateBinding Background}" BorderBrush="White" BorderThickness="2" CornerRadius="2">
                                <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center" ContentSource="Header"/>
                            </Border>
                            <Popup IsOpen="{Binding Path=IsSubmenuOpen, RelativeSource={RelativeSource TemplatedParent}}" Placement="Bottom" x:Name="SubMenuPopup" Focusable="false" PopupAnimation="{DynamicResource {x:Static SystemParameters.MenuPopupAnimationKey}}">
                                <Border x:Name="SubMenuBorder" BorderBrush="{Binding Path=Foreground, RelativeSource={RelativeSource AncestorType={x:Type Menu}}}" BorderThickness="1" Padding="2,2,2,2">
                                    <Grid x:Name="SubMenu" Grid.IsSharedSizeScope="True">
                                        
                                        <StackPanel IsItemsHost="True" KeyboardNavigation.DirectionalNavigation="Cycle" Background="#FFEAA40D" />
                                    </Grid>
                                </Border>
                            </Popup>
                        </Grid>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsPressed" Value="true">
                                <Setter Property="BorderBrush" TargetName="border" Value="#FFEAA40D"/>
                            </Trigger>
                        </ControlTemplate.Triggers>
                            
                    </ControlTemplate>
                </Setter.Value>
