    <TabControl ItemsSource="{DynamicResource OptionCategories}">
       <TabControl.ItemContainerStyle>
          <Style TargetType="{x:Type CategoryView}">
             <Setter Property="Header" Value="{Binding Path=CategoryName}"/>
             <Setter Property="Content" Value="{Binding Path=OptionsViews}"/>
             <Setter Property="ContentTemplate" Value="{StaticResource OptionViewTemplate}"/>
          </Style>
       </TabControl.ItemContainerStyle>
    </TabControl>
