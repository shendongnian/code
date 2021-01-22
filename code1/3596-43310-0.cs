    using System;
    using System.Linq;
    ...
    var a1 = new int[] { 1, 2, 3};
    var a2 = new int[] { 1, 2, 3};
    var a3 = new int[] { 1, 2, 4};
    var x = a1.SequenceEqual(a2); // true
    var y = a1.SequenceEqual(a3); // false
