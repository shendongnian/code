    // no need to type the same assignment 3 times, just
    // new[] up an array and use foreach + lambda
    // everything is properly inferred by csc :-)
    new { itemA, itemB, itemC }
        .ForEach(item => {
            item.Number = 1;
            item.Str = "Hello World!";
        });
