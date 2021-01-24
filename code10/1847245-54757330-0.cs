    [Fact]
    public void ToCreate_Persist_One_Oblect(){
       //arrange:
       var sut = new Repository(context);
       //act
       sut.ToCreate(new XYzClass(){
           ... some properties
       });
       
       //assert:
       var newlyCreatedXyz = context.XYZ.FirstOfDefualt(/*get the item*/);
       Assert.NotNull(newlyCreatedXyz);
       /*Then asset the properties*/
    }
