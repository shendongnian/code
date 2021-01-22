    class AssumptionChainFailed : Exception { }
    void assumeIsNotNull(object obj)
    {
        if (obj == null) throw new AssumptionChainFailed();
    }
