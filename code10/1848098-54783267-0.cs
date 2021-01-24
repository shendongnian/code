      if (InternetConnectionExists)
        {
            //Create an AlertConfig
            var  config = new AlertConfig();
            config.Message = "txt";
            config.Title = "txt";
            config.OkText = "txt";
            //create action of "ok"
            config.OnAction += Show_Dialog2;
            UserDialogs.Instance.Alert(config);          
        
        }
        else
        {
            UserDialogs.Instance.Alert("txt", "txt", "txt");
        }
