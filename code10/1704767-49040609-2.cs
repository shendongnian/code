    xmlns:resDictStyles="clr-namespace:MyNamespace"
    ...
    <ContentView.Resources>
      <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
          <resDictStyles:MyStyles />
        </ResourceDictionary.MergedDictionaries>
      </ResourceDictionary>
    </ContentView.Resources>
    ...
    <Label Style="{StaticResource LabelResDictStyle}" />
