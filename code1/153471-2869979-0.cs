    [Specification]
    public class When_product_service_has_get_product_called_with_any_id 
           : ProductServiceSpecification
    {
       private int _productId;
       private IProduct _actualProduct;
    
       [It] 
       public void Should_return_the_expected_product()
       {
         this._actualProduct.Should().Be.EqualTo(Dep<IProduct>());
       }
    
       [It]
       public void Should_not_have_the_product_modified()
       {
         Dep<IProduct>().AssertWasNotCalled(p => p.Owner = Arg<string>.Is.Anything);
    
         // or write your own extension method:
         // Dep<IProduct>().AssertNoPropertyOrMethodWasCalled();
       }
    
      
       public override void GivenThat()
       {
         var randomGenerator = new RandomGenerator();
         this._productId = randomGenerator.Generate<int>();
    
         Stub<IProductRepository, IProduct>(r => r.GetProduct(this._productId));
       }
    
       public override void WhenIRun()
       {
           this._actualProduct = Sut.GetProduct(this._productId);
       }
    }
