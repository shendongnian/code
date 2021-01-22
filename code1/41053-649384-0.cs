    [Test]
    public void are_equal_when_passed_as_parameters_downcast_to_interfaces() {
        //FAILS!
        CompareTwoEntities(new Terminal() { Id = 1 }, new Terminal() { Id = 1 });
    }
    private void CompareTwoEntities(IEntity e1, IEntity e2) {
        Assert.IsTrue(e1 == e2);
    }
