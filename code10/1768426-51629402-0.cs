    public DataTemplate EvenTemplate { get; set; }
    public DataTemplate UnevenTemplate { get; set; }
    
    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        // TODO: Maybe some more error handling here
        return ((ObservableCollection<Grouping<SelectCategoryViewModel, Product>>)((ListView)container).ItemsSource).IndexOf(item as Product) % 2 == 0 ? EvenTemplate : UnevenTemplate;
    }
