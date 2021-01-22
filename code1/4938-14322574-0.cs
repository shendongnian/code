    List<String> myList = [list containing a bunch of strings]
    var enumerator1 = myList.GetEnumerator();  // Struct of type List<String>.IEnumerator
    enumerator1.MoveNext(); // 1
    var enumerator2 = enumerator1;
    enumerator2.MoveNext(); // 2
    IEnumerator<string> enumerator3 = enumerator2;
    enumerator3.MoveNext(); // 3
    IEnumerator<string> enumerator4 = enumerator3;
    enumerator4.MoveNext(); // 4
