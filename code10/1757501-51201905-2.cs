    var testEnumerator = test1();
    
    while (testEnumerator.MoveNext())
    {
       // i am a CheckBox
       CheckBox checkBox = testEnumerator.Current;
    
    }
    
    foreach (var item in test2())
    {
       // i am a CheckBox also
       CheckBox checkBox = item;
    }
