    [TestMethod]    
    [ExpectedException(typeof(DataAccessException))]    
    public void NHibernateRepositoryBaseDelete()    
    {
        try
        {
            NHibernateRepositoryBaseDeleteHelper<Order, int>(myOrder, myOrder.OrderId);
            NHibernateRepositoryBaseDeleteHelper<OrderDetail, int>(myOrderDetail, myOrderDetail.OrderDetailId);
            NHibernateRepositoryBaseDeleteHelper<Schedule, int>(mySchedule, mySchedule.ScheduleId);
        }
        finally
        {
            // clean up database here
        }   
    }
