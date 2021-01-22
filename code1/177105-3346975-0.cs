    [TestMethod]
    public void ShrinkingThingBreaks()
    {
        try
        {
            InnerShrinkingThingBreaks();
    
            Assert.Fail("This should have caused a TypeLoadException");
        }
        catch
        {
            //  valid
        }
    }
    
    [MethodImpl(MethodImplAttributes.NoInlining)]
    private void InnerShrinkingThingBreaks()
    {
            IShrinkingThing thing = new ProxyForV2.ShrinkingThingImpl();
    }
