    bool isSubset = false;
    var firstOuterList = new List<FirstOuter> { firstOuter };
    var secondOuterList = new List<SecondOuter> { secondOuter };
    
    var jointOuterList = firstOuterList.Join(
          secondOuterList,
          p => new { p.Id, p.Name },
          m => new { m.Id, m.Name },
          (p, m) => new { FOuterList = p, SOuterList = m }
    );
    
    if(jointOuterList.Count != firstOuterList.Count)
    {
          isSubset = false;
          return;
    }
    
    foreach(var item in jointOuterList)
    {
          var jointInnerList = item.firstInnerList.Join(
                     item.firstInnerList,
                     p => new { p.Id, p.Type },
                     m => new { m.Id, m.type },
                     (p, m) => p.Id
          );
    
          if(jointInnerList.Count != item.firstInnerList.Count)
          {
                    isSubset = false;
                    return;
          }
    }
