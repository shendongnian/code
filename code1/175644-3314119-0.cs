    switch (test)
    {
        case SomeEnum.Woo:
            break;
        case SomeEnum.Yay:
            break;
        default:
        {
            string message = string.Format("Value '{0}' for enum '{1}' is not handled.", test, typeof(SomeEnum).Name);
            throw new ArgumentOutOfRangeException(message);
        }
    }
