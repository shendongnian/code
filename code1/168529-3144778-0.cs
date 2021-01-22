    <Grid wpfi:VisualStateAssistant.CurrentVisualState="{Binding Path=CurrentVisualState}">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="*" />
                <ColumnDefinition Width="640" />
                <ColumnDefinition Width="*" />
            </Grid.ColumnDefinitions>
            <Grid.RowDefinitions>
                <RowDefinition Height="*" />
                <RowDefinition Height="480" />
                <RowDefinition Height="*" />
            </Grid.RowDefinitions>
            <VisualStateManager.VisualStateGroups>
                <VisualStateGroup x:Name="ActiveFormStateGroup">
                    <VisualStateGroup.Transitions>
    
                    </VisualStateGroup.Transitions>
                    <VisualState x:Name="Searching">
                        <Storyboard>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="SearchHeaderView">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Visible}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="SearchNavigationView">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Visible}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="SearchResultsView">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Visible}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="DoctorsModuleShell">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Collapsed}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="DoctorsModuleNavigationView">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Collapsed}" />
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
    
                    </VisualState>
                    <VisualState x:Name="DoctorEdit">
                        <Storyboard>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="SearchHeaderView">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Collapsed}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="SearchNavigationView">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Collapsed}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="SearchResultsView">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Collapsed}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="DoctorsModuleShell">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Visible}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="DoctorsModuleNavigationView">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Visible}" />
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
    
                    </VisualState>
                    
                </VisualStateGroup>
                <VisualStateGroup x:Name="VisualAlertsStateGroup">
                    <VisualStateGroup.Transitions>
    
                    </VisualStateGroup.Transitions>
                    <VisualState x:Name="DialogShowing">
                        <Storyboard>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="rectangle">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Visible}" />
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
                    </VisualState>
                    <VisualState x:Name="DialogNotShowing">
                        <Storyboard>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="rectangle">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Collapsed}" />
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
                    </VisualState>
                    <VisualState x:Name="IsWaiting">
                        <Storyboard>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="rectangle">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Visible}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="WaitControl">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Visible}" />
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
                    </VisualState>
                    <VisualState x:Name="IsNotWaiting">
                        <Storyboard>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="rectangle">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Collapsed}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="WaitControl">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Collapsed}" />
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
                    </VisualState>
    
                </VisualStateGroup>
                <VisualStateGroup x:Name="DialogFormsStateGroup">
                    <VisualStateGroup.Transitions>
    
                    </VisualStateGroup.Transitions>
                    <VisualState x:Name="ShowContactInfoEdit">
                        <Storyboard>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="rectangle">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Visible}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="ContactInfoDatagridView">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Visible}" />
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
    
                    </VisualState>
                    <VisualState x:Name="HideContactInfoEdit">
                        <Storyboard>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="rectangle">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Collapsed}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="ContactInfoDatagridView">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Collapsed}" />
    
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
    
                    </VisualState>
                    <VisualState x:Name="ShowDoctorTaxonomyEdit">
                        <Storyboard>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="rectangle">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Visible}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="DoctorsTaxonomyEditView">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Visible}" />
    
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
                    </VisualState>
                    <VisualState x:Name="HideDoctorTaxonomyEdit">
                        <Storyboard>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="rectangle">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Collapsed}" />
                            </ObjectAnimationUsingKeyFrames>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)"
                                                           Storyboard.TargetName="DoctorsTaxonomyEditView">
                                <DiscreteObjectKeyFrame KeyTime="0"
                                                        Value="{x:Static Visibility.Collapsed}" />
    
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
                    </VisualState>
    
                </VisualStateGroup>
            </VisualStateManager.VisualStateGroups>
    
            <DockPanel Grid.Column="0"
                       Grid.Row="0"
                       Grid.ColumnSpan="3"
                       Grid.RowSpan="3">
    
                <!--TOP-->
                <Grid ShowGridLines="False"
                      DockPanel.Dock="Top">
    
                    <views:SearchHeaderView x:Name="SearchHeaderView" />
    
                </Grid>
                <!--BOTTOM-->
                <Grid ShowGridLines="false"
                      DockPanel.Dock="Bottom">
    
                    <views:SearchNavigationView x:Name="SearchNavigationView" />
                    <views:DoctorsModuleNavigationView  x:Name="DoctorsModuleNavigationView"
                                                        Visibility="Collapsed" />
    
                </Grid>
    
                <!--FILL-->
                <Grid ShowGridLines="False">
    
                    <views:SearchResultsView x:Name="SearchResultsView" />
                    <views:DoctorsModuleShell x:Name="DoctorsModuleShell"
                                              Visibility="Collapsed" />
                </Grid>
    
            </DockPanel>
            <Rectangle x:Name="rectangle"
                       RadiusX="2"
                       RadiusY="2"
                       Grid.Column="0"
                       Grid.Row="0"
                       Grid.ColumnSpan="3"
                       Grid.RowSpan="3"
                       Fill="{StaticResource modalFormHitTestRectangleBrush}"
                       IsHitTestVisible="True"
                       Visibility="Collapsed" />
    
            <controls:WaitingControl x:Name="WaitControl"
                                     Width="100"
                                     Height="100"
                                     Visibility="Collapsed"
                                     Grid.Column="1"
                                     Grid.Row="1" />
    
            <views:ContactInfoDatagridView x:Name="ContactInfoDatagridView"
                                           Grid.Column="1"
                                           Grid.Row="1"
                                           Visibility="Collapsed" />
            <views:DoctorsTaxonomyEditView x:Name="DoctorsTaxonomyEditView"
                                           Grid.Column="1"
                                           Grid.Row="1"
                                           Visibility="Collapsed" />
    
        </Grid>
