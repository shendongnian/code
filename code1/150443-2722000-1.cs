    using(IEnumerator<A> list1enum = list1.GetEnumerator())
    using(IEnumerator<B> list2enum = list2.GetEnumerator())    
    while(list1enum.MoveNext() && list2enum.MoveNext()) {
            // list1enum.Current and list2enum.Current point to each current item
        }
