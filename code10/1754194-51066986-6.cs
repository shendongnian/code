    protected void SOLine_OrderQty_FieldVerifying(PXCache cache, PXFieldVerifyingEventArgs e, PXFieldVerifying del)
    {
        if ((decimal?) e.NewValue % 50 != 0)
        {
            cache.RaiseExceptionHandling<SOLine.orderQty>(e.Row, ((SOLine)e.Row).OrderQty,
                new PXSetPropertyException("Please enter a value in multiples of 50.", PXErrorLevel.Warning));
        }
    
        if (del != null)
        {
            del(cache, e);
        }
    }
