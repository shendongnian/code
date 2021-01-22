    var array = new [] { 1, 2, 3, 4, 5, 6, 7, 8 };
    var pass1 = array.SkipAndRotate().ToArray();
    var pass2 = pass1.SkipAndRotate().ToArray();
    var pass3 = pass2.SkipAndRotate().ToArray();
    var pass4 = pass3.SkipAndRotate().ToArray();
