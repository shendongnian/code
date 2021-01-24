    public class MyObject
    {
        public int Id { get; }
        public ICommand DetailsCommand { get; }
        // Other properties if needed
        public MyObject(int id)
        {
            Id = id;
            DetailsCommand = new Command(ShowDetails);
        }
        private async void ShowDetails()
        {
            var selected = obj as Tasks;
            await _navigation.PushAsync(new DetailsPage(Id));
        }
    }
