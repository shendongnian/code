    SampleEnum Result;
    bool Success = SampleEnum.TryParse(inputText, true, out Result);
    if(!Success){
         //value was not in the enum values
    }else{
       switch (Result) {
          case SampleEnum.Value1:
          break;
          case SampleEnum.Value2:
          break;
          default:
          //do default behaviour
          break;
       }
    }
