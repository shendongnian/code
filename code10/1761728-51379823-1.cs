    public DatabaseResultEnum DoSmth(int someId)
    {
        return this.DoSomething(context => context
                   .DatabaseResultEnum.FirstOrDefault(y => y.Id == someId));
    }
