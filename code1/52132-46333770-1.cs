    var result;
    if (DoThing(out result))
    {
        if (DoOtherThing(out result))
        {
            if (DoFinalThing(out result))
            {
                success = true;
            }
        }
    }
