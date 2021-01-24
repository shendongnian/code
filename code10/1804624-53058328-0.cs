    <Style x:Key="MyListViewStyle" TargetType="ListView">
        <Setter Property="IsTabStop" Value="False"/>
        <Setter Property="TabNavigation" Value="Once"/>
        <Setter Property="IsSwipeEnabled" Value="True"/>
        <Setter Property="ScrollViewer.HorizontalScrollBarVisibility" Value="Disabled"/>
        <Setter Property="ScrollViewer.VerticalScrollBarVisibility" Value="Auto"/>
        <Setter Property="ScrollViewer.HorizontalScrollMode" Value="Disabled"/>
        <Setter Property="ScrollViewer.IsHorizontalRailEnabled" Value="False"/>
        <Setter Property="ScrollViewer.VerticalScrollMode" Value="Enabled"/>
        <Setter Property="ScrollViewer.IsVerticalRailEnabled" Value="True"/>
        <Setter Property="ScrollViewer.ZoomMode" Value="Disabled"/>
        <Setter Property="ScrollViewer.IsDeferredScrollingEnabled" Value="False"/>
        <Setter Property="ScrollViewer.BringIntoViewOnFocusChange" Value="True"/>
        <Setter Property="UseSystemFocusVisuals" Value="{StaticResource UseSystemFocusVisuals}"/>
        <Setter Property="ItemContainerTransitions">
            <Setter.Value>
                <TransitionCollection>
                    <AddDeleteThemeTransition/>
                    <ContentThemeTransition/>
                    <ReorderThemeTransition/>
                    <EntranceThemeTransition IsStaggeringEnabled="False"/>
                </TransitionCollection>
            </Setter.Value>
        </Setter>
        <Setter Property="ItemsPanel">
            <Setter.Value>
                <ItemsPanelTemplate>
                    <VirtualizingStackPanel 
                        Orientation="Horizontal"  
                        VerticalAlignment="Top"
                        ScrollViewer.HorizontalScrollMode="Enabled"
                        ScrollViewer.VerticalScrollMode="Disabled"
                        />
                </ItemsPanelTemplate>
            </Setter.Value>
        </Setter>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="ListView">
                    <Border Background="{TemplateBinding Background}" BorderThickness="{TemplateBinding BorderThickness}" BorderBrush="{TemplateBinding BorderBrush}">
                        <ScrollViewer x:Name="ScrollViewer" AutomationProperties.AccessibilityView="Raw" 
                                      BringIntoViewOnFocusChange="{TemplateBinding ScrollViewer.BringIntoViewOnFocusChange}" 
                                      HorizontalScrollBarVisibility="{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}" 
                                      HorizontalScrollMode="{TemplateBinding ScrollViewer.HorizontalScrollMode}" 
                                      IsDeferredScrollingEnabled="{TemplateBinding ScrollViewer.IsDeferredScrollingEnabled}" 
                                      IsVerticalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsVerticalScrollChainingEnabled}" 
                                      IsHorizontalRailEnabled="{TemplateBinding ScrollViewer.IsHorizontalRailEnabled}" 
                                      IsVerticalRailEnabled="{TemplateBinding ScrollViewer.IsVerticalRailEnabled}" 
                                      IsHorizontalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsHorizontalScrollChainingEnabled}"
                                      TabNavigation="{TemplateBinding TabNavigation}" 
                                      VerticalScrollMode="{TemplateBinding ScrollViewer.VerticalScrollMode}" 
                                      VerticalScrollBarVisibility="{TemplateBinding ScrollViewer.VerticalScrollBarVisibility}" 
                                      ZoomMode="{TemplateBinding ScrollViewer.ZoomMode}">
                            <ItemsPresenter Footer="{TemplateBinding Footer}" 
                                            FooterTransitions="{TemplateBinding FooterTransitions}"
                                            FooterTemplate="{TemplateBinding FooterTemplate}"
                                            Header="{TemplateBinding Header}" 
                                            HeaderTransitions="{TemplateBinding HeaderTransitions}" 
                                            HeaderTemplate="{TemplateBinding HeaderTemplate}"
                                            Padding="{TemplateBinding Padding}"/>
                        </ScrollViewer>
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
