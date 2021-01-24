    public static string GetUriByAction(
            this LinkGenerator generator,
            string action,
            string controller,
            object values,
            string scheme,
            HostString host,
            PathString pathBase = default,
            FragmentString fragment = default,
            LinkOptions options = default)
