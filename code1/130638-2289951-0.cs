public class Service : INotifyPropertyChanged
{
    public delegate void ResultEvent(bool result);
    public event ResultEvent Result;
    // Where's the raise property changed event handler?
    private void OnServiceResult(bool result){
        if (this.Result != null) this.Result(result);
    }
}
