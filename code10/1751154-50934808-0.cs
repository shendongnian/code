    [Test]
    public void simple_select_test()
    {
        using (var conn = new SqlConnection(@"Data Source=.\sqlexpress; Integrated Security=true; Initial Catalog=test"))
        {
            var result = conn.Query<User>(
                "select * from (select Id = 420, Login = 'foo', Passwd = 'bar') a where Login=@login and Passwd=@passwd",
                new {login = "foo", passwd = "bar"}).First();
    
            Assert.That(result.Login, Is.EqualTo("foo"));
            Assert.That(result.Passwd, Is.EqualTo("bar"));
        }
    }
