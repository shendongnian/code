    static void Main(string[] args)
    {
        MainViewModel mainViewModel = new MainViewModel();
        Child1ViewModel child1 = new Child1ViewModel();
        Child2ViewModel child2 = new Child2ViewModel();
        mainViewModel.UpdateName("Name1");
        Console.WriteLine(child1.Name);
        Console.WriteLine(child2.Name);
    }
