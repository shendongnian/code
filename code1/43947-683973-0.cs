    output = transform(FooSource, TransformA);
    output = transform(BarSource, TransformB);  // I know output is overwritten, but
                    // it is in the askers' example as well
    transform(var itmSource, var transform) {
        var output=source.GetRawOutput();  // Sorry, you never said where source came from.
        var items = itmSource.GetItems();
        output=transform.TransformOutput(output, p =>
            {
                GetContent(p, items.GetNext()); // GetContent may need to be passed in
                                        // you didn't say where those calls came from.
                                     // Chances are they should be two methods in
                                     // sibling objects and the appropriate object should
                                     // be passed in.
            });
        }
        return output;
    }
