    <ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
                 xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
                 xmlns:behaviors="clr-namespace:EventToCommandBehavior"
                 x:Class="FormsBehaviors.Views.MainPage">
        <ContentPage.Resources>
            <ResourceDictionary>
                <behaviors:SelectedItemEventArgsToSelectedItemConverter x:Key="SelectedItemConverter" />
            </ResourceDictionary>
        </ContentPage.Resources>
        <ContentPage.Content>
            <ListView ItemsSource="{Binding Thingies}">
                <ListView.Behaviors>
                    <behaviors:EventToCommandBehavior EventName="ItemSelected" 
                                                      Command="{Binding FooCommand}" 
                                                      Converter="{StaticResource SelectedItemConverter}" />
                </ListView.Behaviors>
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <TextCell Text="{Binding Name}"/>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
        </ContentPage.Content>
    </ContentPage>
