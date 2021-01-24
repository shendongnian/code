    private IEnumerator IncrementSpeed ()
    {
        //_startValue = 300f;
        //_endValue = 0f;
        //_changeDuration = 7f;
        focalLength = _startValue;
        changeRate = (_endValue - _startValue) / _changeDuration;
        while (focalLength >= _endValue)
        {
            focalLength += changeRate * Time.deltaTime;
            yield return null;
        }
    }
