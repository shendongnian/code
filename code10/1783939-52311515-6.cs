    <ContentView.Resources>
        <ResourceDictionary>
            <Style x:Key="CachedImageStyle" TargetType="{x:Type ffimageloading:CachedImage}">
               <Setter Property="HorizontalOptions" Value="Center" />
               <Setter Property="VerticalOptions" Value="Center" />
               <Setter Property="HeightRequest">
                 <Setter.Value>
                   <OnIdiom x:TypeArguments="x:Double" Tablet="800" Phone="400" />
                 </Setter.Value>
               </Setter>
             </Style>
        </ResourceDictionary>
    </ContentView.Resources>
    
    <ContentView.Content>
        <!-- ... -->
        <ffimageloading:CachedImage
            x:Name="cachedImg"
            Style="{StaticResource CachedImageStyle}">
          </ffimageloading:CachedImage>
        <!-- ... -->
    </ContentView.Content>
