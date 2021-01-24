        MyMembers = MyMembers.GroupBy(x => x.IdKey)
          .Select(g => new Members(
             g.Key, //Id will be same as you shown in question
             g.FirstOrDefault().name, //assuming name will be same in all
             g.Select(x => x.RelationBeginDate).Min().ToString("dd-MM-yyyy hh:mm:ss"), //Min begin date
             g.Select(x => x.RelationEndDate).Max().ToString("dd-MM-yyyy hh:mm:ss"),   //Max end date
             g.Any( x => x.isOriginal))).ToList();      //if isOriginal = true found
