    <ContentPage.Resources>
        <ResourceDictionary>
            <converter:OzViewConverter x:Key="OzViewConverter" />
        </ResourceDictionary>
    </ContentPage.Resources>
    
     <Label IsVisible="{Binding Item.Unit, Converter={StaticResource OzViewConverter}}">
             <Label.FormattedText>
                   <FormattedString>
                          <Span Text="Size: "/>
                          <Span FontAttributes="Bold" Text="{Binding Item.Size , Mode=OneWay}"/>
                          <Span FontAttributes="Bold" Text="{Binding Item.Unit, Mode=OneWay}"/>
                   </FormattedString>
               </Label.FormattedText>
           </Label>
