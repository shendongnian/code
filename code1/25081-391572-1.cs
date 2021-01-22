    [Test] 
    public void Should_be_able_to_use_enumerator_more_than_once() 
    {
       var numbers = Isolate.Fake.Instance<INumbers>();
       Isolate.WhenCalled(() => numbers).WillReturnCollectionValuesOf(new List<int>{ 1, 2, 3 });
       var sut = new ObjectThatUsesEnumerator(); 
       var correctResult = sut.DoSomethingOverEnumerator2Times(numbers); 
       Assert.IsTrue(correctResult); 
    }
