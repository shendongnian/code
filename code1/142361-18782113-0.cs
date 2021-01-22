    var t = objects.GetType(); // to be compatible with the question
    bool isIEnumerable = false;
    foreach (var i in t.GetInterfaces())
    {
        if (i == typeof(IEnumerable))
        {
            isIEnumerable = true;
            break;
        }
    }
