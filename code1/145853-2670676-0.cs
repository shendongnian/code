    //invoke pipeline
    collection = pipeline.Invoke();
    
    // check for errors (non-terminating)
    if (pipeline.Error.Count > 0)
    {
      //iterate over Error PipeLine until end
      while (!pipeline.Error.EndOfPipeline)
      {
        //read one PSObject off the pipeline
        var value = pipeline.Error.Read() as PSObject;
        if (value != null)
        {
          //get the ErrorRecord
          var r = value.BaseObject as ErrorRecord;
          if (r != null)
          {
            //build whatever kind of message your want
            builder.AppendLine(r.InvocationInfo.MyCommand.Name + " : " + r.Exception.Message);
            builder.AppendLine(r.InvocationInfo.PositionMessage);
            builder.AppendLine(string.Format("+ CategoryInfo: {0}", r.CategoryInfo));
            builder.AppendLine(
            string.Format("+ FullyQualifiedErrorId: {0}", r.FullyQualifiedErrorId));
          }
        }
      }
      return builder.ToString();
    }
