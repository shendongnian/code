    public void test_the_add_pool_method()
        {
            var date = DateTime.Parse(DateTime.Now.ToString(), new CultureInfo("en-US", true)).Date;
    
        var pool = new PoolDto
         {
             RequestorId = 1,
             ClientId = 1,
             Description = "Pool request",
             PoolStates = new List<PoolState>(),
             BookingDate = date,
             BookingFrom = date,
             BookingTo = date.AddDays(1)
         };
    
         service.AddPool(PoolDto,1); //service.AddPool(pool ,1);
    
          Assert.That(Pools.Count(), Is.EqualTo(1));
          Assert.That(Pools.First().RequestorId, Is.EqualTo(1));
          Assert.That(Pools.First().ClientId, Is.EqualTo(1));
          Assert.That(Pools.First().Description, Is.EqualTo("Pool request"));
          Assert.That(Pools.First().BookingDate, Is.EqualTo(DateTime.Now.Date));
          Assert.That(Pools.First().BookingFrom, Is.EqualTo(DateTime.Now.Date));
          Assert.That(Pools.First().BookingTo, Is.EqualTo(DateTime.Now.AddDays(1).Date));
    }
