    switch (exJson.Value<string>("ClassName")) {
        case "your.namespace.SomeExceptionType":
            {
                SomeExceptionType ex = exJson.ToObject<SomeExceptionType>();
            }
            break;
        case "your.namespace.OtherExceptionType":
            {
                OtherExceptionType ex = exJson.ToObject<OtherExceptionType>();
            }
            break;
        default:
            {
                Exception ex = exJson.ToObject<Exception>();
            }
            break;
        }
     
