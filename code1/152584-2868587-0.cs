    [Specification]
    When_fruit_manager_has_delete_called_with_existing_fruit : FruitManagerSpecifcation
    {
      private IEnumerable<IFruit> _fruits;
    
      [It]
      public void Should_remove_the_expected_fruit()
      {
        Assert.Inconclusive("Please implement");
      }
    
      [It]
      public void Should_not_remove_any_other_fruit()
      {
        Assert.Inconclusive("Please implement");
      }
    
      [It]
      public void Should_reorder_the_ids_of_the_remaining_fruit()
      {
        Assert.Inconclusive("Please implement");
      }
    
      /// <summary>
      /// Setup the SUT before creation
      /// </summary>
      public override void GivenThat()
      {
         _fruits = new List<IFruit>();
    
         3.Times(_fruits.Add(Mock<IFruit>()));
    
         this._fruitToDelete = _fruits[1];
    
         // this fruit is injected in th Sut
         Dep<IEnumerable<IFruit>>()
                    .Stub(f => ((IEnumerable)f).GetEnumerator())
                    .Return(this.Fruits.GetEnumerator())
                    .WhenCalled(mi => mi.ReturnValue = this._fruits.GetEnumerator());
    
      }
    
      /// <summary>
      /// Delete a fruit
      /// </summary>
      public override void WhenIRun()
      {
        Sut.Delete(this._fruitToDelete);
      }
    }
