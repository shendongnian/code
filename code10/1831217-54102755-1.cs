    <ContentPage.Resources>
        <ResourceDictionary>
            <local:IntToColorConverter x:Key="intToColor" />
        </ResourceDictionary>
    </ContentPage.Resources>
    <Label ... 
         TextColor="{Binding Happiness, Converter={StaticResource intToColor}}">
