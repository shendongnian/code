     public class MainPageViewModel
     {
         public MainPageViewModel()
         {
             GetJson();
         }
         public ObservableCollection<RoomObject> Items { get; set; } = new ObservableCollection<RoomObject>();
         private async void GetJson()
         {
             var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync("json.txt");
             string json = await Windows.Storage.FileIO.ReadTextAsync(file);
             var item = JsonConvert.DeserializeObject<Item>(json);
             var roomitem = new RoomObject(item);
             Items.Add(roomitem);
         }  
    
     }
