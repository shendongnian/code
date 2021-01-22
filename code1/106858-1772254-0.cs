        Container c= new Container();
        IEntity entity = c;
        new Command().ApplyCommand(ref entity);           
        Assert.IsInstanceOfType(entity, typeof(Container));
        c = (Container)entity;
        Assert.AreEqual(c.Id, 20); 
