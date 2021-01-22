    Day d1 = new Day();
    Day d2 = new Day();
    LinkedList<Day> days = new LinkedList<Day>();
    // Day's instance doesn't have Next. Its the LinkedListNode that should be used.
    LinkedListNode<Day> d1Node = days.AddLast(d1); 
    days.AddLast(d2);
