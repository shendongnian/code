    <ContentPage.Resources>
        <ResourceDictionary>
            <local:StringToBoolConverter x:Key="stringToBool" />
        </ResourceDictionary>
    </ContentPage.Resources>
    <!--your code --->
    <Button  Text="Abrir" 
             IsVisible="{Binding statusDescr, Converter={StaticResource stringToBool}}"  
             BackgroundColor="#1C97D5" 
             TextColor="White" />
