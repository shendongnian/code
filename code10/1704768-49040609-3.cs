    xmlns:resDictStyles="clr-namespace:MyNamespace"
    ...
    <ContentPage.Resources>
      <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
          <resDictStyles:MyStyles />
        </ResourceDictionary.MergedDictionaries>
        <Style x:Key="LabelPageStyle" TargetType="Label" BasedOn="{StaticResource LabelResDictStyle}">
          <Setter Property="FontSize" Value="20"></Setter>
        </Style>
      </ResourceDictionary>
    </ContentPage.Resources>
    ...
    <Label Style="{StaticResource LabelPageStyle}" />
    
