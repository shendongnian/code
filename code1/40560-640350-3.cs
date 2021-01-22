    // Method name shortened for simplicity, and I'm assuming that type inference
    // will work too.
    public void NHibernateRepositoryBaseDelete()
    {
        ExpectException<DataAccessException>(() => 
            DeleteHelper(myOrder, myOrder.OrderId));
        ExpectException<DataAccessException>(() => 
           DeleteHelper(myOrderDetail, myOrderDetail.OrderDetailId));
        ExpectException<DataAccessException>(() => 
           DeleteHelper(mySchedule, mySchedule.ScheduleId));
    }
