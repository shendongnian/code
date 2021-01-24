    public Form1()
    {
        InitializeComponent();
        EventPublisher.Instance.Subscribe<NewUserCreated>
            (n => listBoxUsers.Items.Add(n.User.Name));
    }
    
    ...
    
    // some other class
    private void Form2()
    {
    
        var user = new User()
                   {
                       Name = textBoxUserName.Text,
                       Password = textBoxPassword.Text,
                       Email = textBoxEmail.Text
                   };
        EventPublisher.Instance.Publish(new NewUserRequested(user));
    }
