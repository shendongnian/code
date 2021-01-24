C#
public ObservableCollection<ChatMessage> Messages { get; set; } = new ObservableCollection<ChatMessage>();
public async Task InitSignalRAsync()
{
  var context = SynchronizationContext.Current;
  hubConnection = new HubConnectionBuilder().WithUrl("http://localhost:5000/chatHub").Build();
  await hubConnection.StartAsync();
  hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
  {
    var mess = new ChatMessage
    {
      user = user,
      message = message,
    };
    context.Post(_ => Messages.Add(mess));
  });
}
I also changed your [`async void` to `async Task`][2] (again, better reusability and testability), and made a new `ChatMessage` for each chat message, which I believe is the intended behavior.
  [1]: https://stackoverflow.com/a/54492955/263693
  [2]: https://msdn.microsoft.com/en-us/magazine/jj991977.aspx
