        List<Post> posts = new List<Post>();
        foreach(Notification item in notification?.Values){
          if (item.posts != null){
            foreach(var subItem in item.posts.Values){
               posts.AddRange(subItem);
             }
           }
        }
         
        var _schoolNotification = new ObservableCollection<Post>(posts);
