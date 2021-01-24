    var list = System.AppDomain.CurrentDomain.GetAssemblies().SelectMany
        (
            a => a.GetTypes().SelectMany
            (
                t => t.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public).Where
                (
                    p => p.GetIndexParameters().Length > 0
                )
                .Select
                (
                    prop => string.Format
                    (
                        "{0}.{1}[{2}]",
                        t.FullName,
                        prop.Name,
                        string.Join
                        (
                            ",",
                            prop.GetIndexParameters().Select(ip => ip.Name)
                        )
                    )
                )
            )
        );
