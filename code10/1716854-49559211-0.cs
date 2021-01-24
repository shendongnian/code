    string name = null;
    button.Click += delegate { 
            name = myName.Text;
            var welcome = new Intent(this, typeof(Welcome));
            welcome.PutExtra("name", name);
            StartActivity(welcome);
        };
