        for(LinkedListNode<MyClass> it = myCollection.First; it != null; )
        {
            LinkedListNode<MyClass> next = it.Next;
            if(it.Value.removalCondition == true)
                  myCollection.Remove(it); // as a side effect it.Next == null
    
            it = next;
        }
