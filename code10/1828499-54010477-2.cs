    //setup
    //hold the group sizes we want to make - you say your user chose this
    int[] groupSizes = new[] {3, 4, 4, 5, 5, 6};
    //you have lists of people from somewhere
    List<Person> boys = new List<Person>();
    for(int i = 0; i < 15; i++)
      boys.Add(new Person());
    List<Person> girls = new List<Person>();
    for(int i = 0; i < 12; i++)
      girls.Add(new Person());
    //logic of random grouping
    List<List<Person>> groups = new List<List<Person>>();
    Random r = new Random();
    //for each groupsize we make
    foreach(int g in groupSizes){ 
      List<Person> group = new List<Person>(); //new group
      for(int i = 0; i < g; i++){ //take people, up to group size
        //take boys and girls alternately
        var fr = (i % 2 == 0) ? boys : girls;
        //if there are no more boys/girls, take other gender instead
        if(fr.Count == 0) 
          fr = (i % 2 == 0) ? girls : boys;
  
        //choose a person at random, less than list length
        var ri = r.Next(fr.Count);
        //add to the current grouping
        group.Add(fr[ri]);
        //remove from consideration
        fr.RemoveAt(ri);
      }
      //group is made, store in the groups list
      groups.Add(group);
    }
