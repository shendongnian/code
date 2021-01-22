    public void FilterControllerTestRemoveFilterByProductAttributeIsOfTypePost()
    {
        FilterController controller = new FilterController();
        MvcAssert.HasPostAction(controller, "RemoveFilterByProduct", 1);
    }
