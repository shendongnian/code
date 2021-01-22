    Output0Buffer.AddRow()
    for (ix = 0; ix < column.Length; ix++)
    {
        switch(ix)
        { case 0:
            Output0Buffer.Column0 = columns[ix];
            break;
          case 1:
            ...
        }
    }
