            Customer cust = new Customer();
            Customer orig = ctx.Customers.GetOriginalEntityState(cust);
            Assert.IsNull(orig);
            
            cust = new Customer();
            ctx.Customers.Attach(cust);
            orig = ctx.Customers.GetOriginalEntityState(cust);
            Assert.IsNotNull(orig);
            Assert.AreNotSame(cust,orig);
