    //Deserialize the JSON data
      var notification = JsonConvert.DeserializeObject<Notification>(apiContent); 
        List<Post> posts = new List<Post>();
          if (notification?.posts != null){
            foreach(var item in notification.posts.Values){
               posts.AddRange(item);
             }
           }
        var _schoolNotification = new ObservableCollection<Post>(posts);
