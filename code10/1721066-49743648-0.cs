    public float someOtherMethod()
    {
        float result;
        StartCoroutine(getXXX(out result));
        return result;
    }
    IEnumerator getXXX(out float result)
    {
        //more code here...
        yield return StartCoroutine(YYY((r) => result = r));
        //more code here...
    }
    IEnumerator YYY(System.Action<float> callback)
    {
        //your logic here...
    }
