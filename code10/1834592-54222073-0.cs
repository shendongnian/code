        List<Post> posts = new List<Post>();
        foreach(Notification item in notification.Values){
               posts.AddRange(item.posts);
        }
         
        var _schoolNotification = new ObservableCollection<Post>(posts);
