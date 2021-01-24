    <Style TargetType="{x:Type ComboBoxItem}">
         <Style.Resources>
             <SolidColorBrush x:Key="WarningBrush" Color="#FF6666" />
             <SolidColorBrush x:Key="WarningHighlightedBrush" Color="#FF8888" />
             <SolidColorBrush x:Key="DefaultHighlightedBrush" Color="LightBlue" />
         </Style.Resources> 
         
         <Setter Property="Background" Value="{StaticResource WarningBrush}" />
             <Setter Property="Template">
                 <Setter.Value>
                     <ControlTemplate TargetType="{x:Type ComboBoxItem}">
                         <Border x:Name="myBorder" Background="{TemplateBinding Background}">
                            <ContentPresenter />
                         </Border>
                         <ControlTemplate.Triggers>
                             <MultiDataTrigger>
                                 <MultiDataTrigger.Conditions>
                                     <Condition Binding="{Binding RelativeSource={RelativeSource Self}, Path=IsMouseOver}" Value="True"/>
                                     <Condition Binding="{Binding RelativeSource={RelativeSource Self}, Path=Value.IsWarning}" Value="True"/>
                                 </MultiDataTrigger.Conditions>
                                 <Setter TargetName="myBorder" Property="Background" Value="{StaticResource WarningHighlightedBrush}" />
                             </MultiDataTrigger>
                             <MultiDataTrigger>
                                 <MultiDataTrigger.Conditions>
                                     <Condition Binding="{Binding RelativeSource={RelativeSource Self}, Path=IsMouseOver}" Value="True"/>
                                     <Condition Binding="{Binding RelativeSource={RelativeSource Self}, Path=Value.IsWarning}" Value="False"/>
                                 </MultiDataTrigger.Conditions>
                                 <Setter TargetName="myBorder" Property="Background" Value="{StaticResource DefaultHighlightedBrush}" />
                             </MultiDataTrigger>
                         </ControlTemplate.Triggers>
                     </ControlTemplate>
                 </Setter.Value>
             </Setter>
         </Style>
