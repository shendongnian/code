    public async Task DoSomething1()
    {
        var blog = await _blogRepository.GetById(1);
        Console.WriteLine(blog.Title); // this line has the bug
    }
