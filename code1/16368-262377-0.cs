    <Page x:Class="MyPage" DataContext="{Binding RelativeSource={RelativeSource Self}}">
        <ListBox>
           <ListBox.ItemsSource>
             <CompositeCollection>
               <CollectionContainer
                 Collection="{Binding Items}" />
               <CollectionContainer
                 Collection="{Binding RelatedItems}" />
             </CompositeCollection>
           </ListBox.ItemsSource>
        </ListBox>
    </Page>
    public class MyPage : Page
    {
        public ReadOnlyCollection<data> Items
        {
            get { returm items; }
        }
    
        public ReadOnlyCollection<data> RelatedItems
        {
            get { returm relatedItems; }
        }
    }
