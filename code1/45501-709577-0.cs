    var qry = from objectA in GetObjectAs()
              join objectB in GetObjectBs()
                 on objectA.Id equals objectB.AId
              select new { A = objectA,
                  objectB.SomeProp, objectB.SomeOtherProp };
    foreach(var item in qry) {
        item.A.SomeProp = item.SomeProp;
        item.A.SomeOtherProp = item.SomeOtherProp;
        // perhaps "yield return item.A;" here
    }
