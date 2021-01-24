    Dictionary<int, RoutedEventHandler> delegateList = new Dictionary<int, RoutedEventHandler>();
    private void playPlayerCrowdFile(int index)
    {
         var mediaOpenedHandler = (sender, e) => 
         InterruptMediaElement_MediaOpened(sender, e, index);
         selZoneBOList[index].InterruptMediaElement.MediaOpened += mediaOpenedHandler;
         delegateList.Add(index, mediaOpenedHandler);
    }
    
    private void InterruptMediaElement_MediaOpened(object sender, RoutedEventArgs e, int index)
    {
         Console.WriteLine("count before " + delegateList.Count);
         selZoneBOList[index].InterruptMediaElement.MediaOpened -= delegateList[index];
         delegateList.Remove(index);
         Console.WriteLine("count after " + delegateList.Count);
    }
