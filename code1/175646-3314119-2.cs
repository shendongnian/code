    switch (test)
    {
        case SomeEnum.Woo:
            break;
        case SomeEnum.Yay:
            break;
        default:
        {
            string msg = string.Format("Value '{0}' for enum '{1}' is not handled.", 
                test, test.GetType().Name);
            throw new ArgumentOutOfRangeException(msg);
        }
    }
