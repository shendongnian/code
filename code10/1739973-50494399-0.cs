    public event EventHandler MyEvent;
    private void MyButton_Click(object sender, EventArgs e)
    {
        Application.ExitThread();
        this.MyEvent+= (s, e) =>
        {
            Console.WriteLine("This will be executed");
        };
        Console.WriteLine("This line is also executed");
    }
