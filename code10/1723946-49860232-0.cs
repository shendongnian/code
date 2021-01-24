    var sourceArray = new [] {1, 5, 9.2, 6, 17}.ToList() // for simplicity i use a list
    
    var closestToX = sourceArray.GetValueClosestTo(6); // this return 6
    closestToX = sourceArray.GetValueClosestTo(15); // this return 17
    closestToX = sourceArray.GetValueClosestTo(5.2); // this return 5
