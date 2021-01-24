    var l1count = l1.Count;
    var l2count = l2.Count;
    var ocount = l1count + l2count;
    var l1o = l1.OrderBy(o => o.updateDate).ToList();
    var l2o = l2.OrderBy(o => o.updateDate).ToList();
    for (int j1 = 0, j2 = 0; j1 + j2 < ocount;) {
        if (j1 < l1count && (l1o[j1].updateDate <= l2o[j2].updateDate || j2 >= l2count)) {
            // process l1o[j1]
            ++j1;
        }
        else {
            // process l2o[j2]
            ++j2;
        }
    }
