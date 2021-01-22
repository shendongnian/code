    [Test]
    [Sequence(16)]
    [Requires("POConstructor")]
    [Requires("WorkOrderConstructor")]
    public void ClosePO()
    {
      po.Close();
    
      // one charge slip should be added to both work orders
    
      Assertion.Assert(wo1.ChargeSlipCount==1,
        "First work order: ChargeSlipCount not 1.");
      Assertion.Assert(wo2.ChargeSlipCount==1,
        "Second work order: ChargeSlipCount not 1.");
      ...
    }
