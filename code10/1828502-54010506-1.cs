    private string PopBoy()
    {
        if(boys.Count>0)
        {
            var name = boys[0];
            boys.RemoveAt(0);
            return name;
        }
        else
        {
            return PopGirl();
        }
    }
    private string PopGirl()
    {
        if(girls.Count>0)
        {
            var name = girls[0];
            girls.RemoveAt(0);
            return name;
        }
        else
        {
            return PopBoy();
        }
    }
