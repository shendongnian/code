    [Fact]
    public void GetAll_Success() {
        ActionResult<IEnumerable<string>> result = _objValuesController.Get();
        IEnumerable<string> actual = result.Value;
        Assert.Equal<IEnumerable<string>>(expected, actual);
    }
