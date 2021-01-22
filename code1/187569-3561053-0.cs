    public class Presenter()
    {
        private ListCollectionView lcv;
    
        public Presenter()
        {
            this.lcv = (ListCollectionView)CollectionViewSource.GetDefaultView(animalsCollection);
            listControl.ItemsSource = this.lcv;
        }
    }
