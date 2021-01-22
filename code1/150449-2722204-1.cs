    using(var enum1 = list1.GetEnumerator())
    using(var enum2 = list2.GetEnumerator())
    {
        while(true)
        {
        	bool moveNext1 = enum1.MoveNext();
        	bool moveNext2 = enum2.MoveNext();
        	if (moveNext1 != moveNext2)
        		throw new InvalidOperationException();
        	if (!moveNext1)
        		break;
        	var a = moveNext1.Current;
        	var b = moveNext2.Current;
        	// use a and b
        }
    }
