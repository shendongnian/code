    public static GetLocalizedDescription(this ILocalizedEntity entity)
    {
        if (entity == null)
        {
            return String.Empty;
        }
        else
        {
            switch (Session.Language)
            {
                case Language.English:
                    return entity.descrEn;
                    break;
                case Language.French:
                    return entity.descrFr;
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
